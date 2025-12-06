using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.Helpers
{
    public class JWTHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public JWTHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWTSettings");
        }

        public string GenerateToken(int userId, string userName, IList<string> roles)
        {
            var securityKey = _jwtSettings.GetSection("securityKey").Value 
                ?? throw new InvalidOperationException("JWT security key is not configured");
            var validIssuer = _jwtSettings.GetSection("validIssuer").Value 
                ?? throw new InvalidOperationException("JWT issuer is not configured");
            var validAudience = _jwtSettings.GetSection("validAudience").Value 
                ?? throw new InvalidOperationException("JWT audience is not configured");
            var expiryInHours = _jwtSettings.GetSection("expiryInHours").Value 
                ?? throw new InvalidOperationException("JWT expiry is not configured");

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(expiryInHours)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
