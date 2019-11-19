using AutoMapper;
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
            });
        }
    }
}
