using AutoMapper;
using Hobbyist_Network.Application.DTOs.Contact;
using Hobbyist_Network.Application.DTOs.Event;
using Hobbyist_Network.Application.DTOs.Hobby;
using Hobbyist_Network.Application.DTOs.HobbyCategory;
using Hobbyist_Network.Application.DTOs.User;
using Hobbyist_Network.Domain.Entities;


namespace Hobbyist_Network.WebAPI.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<HobbyCategory, HobbyCategoryDto>();
                cfg.CreateMap<Hobby, HobbyDto>();
                cfg.CreateMap<Event, EventDto>();
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<GetUsersDto, UserDto>()
                    .ForMember(
                        dest => dest.City,
                        opt => opt.MapFrom(src => src.Value.City)
                    )
                    .ForMember(
                        dest => dest.DateOfBirth,
                        opt => opt.MapFrom(src => src.Value.DateOfBirth)
                    )
                    .ForMember(
                        dest => dest.Description,
                        opt => opt.MapFrom(src => src.Value.Description)
                    )
                    .ForMember(
                        dest => dest.Email,
                        opt => opt.MapFrom(src => src.Value.Email)
                    )
                    .ForMember(
                        dest => dest.Facebook,
                        opt => opt.MapFrom(src => src.Value.Facebook)
                    )
                    .ForMember(
                        dest => dest.FirstName,
                        opt => opt.MapFrom(src => src.Value.FirstName)
                    )
                    .ForMember(
                        dest => dest.Gender,
                        opt => opt.MapFrom(src => src.Value.Gender)
                    )
                    .ForMember(
                        dest => dest.Hobbies,
                        opt => opt.MapFrom(src => src.Value.Hobbies)
                    )
                    .ForMember(
                        dest => dest.Id,
                        opt => opt.MapFrom(src => src.Value.Id)
                    )
                    .ForMember(
                        dest => dest.Instagram,
                        opt => opt.MapFrom(src => src.Value.Instagram)
                    )
                    .ForMember(
                        dest => dest.LastName,
                        opt => opt.MapFrom(src => src.Value.LastName)
                    )
                    .ForMember(
                        dest => dest.PhoneNumber,
                        opt => opt.MapFrom(src => src.Value.PhoneNumber)
                    );
            });
        }
    }
}
