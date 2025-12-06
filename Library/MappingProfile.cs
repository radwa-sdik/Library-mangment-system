using AutoMapper;
using Library.DTOs;

namespace Library
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpReqDTO, Models.ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateBookDTO, Models.Book>()
                .ForMember(dest => dest.AvailableCopies, opt => opt.MapFrom(src => src.TotalCopies));
        }
    }
}
