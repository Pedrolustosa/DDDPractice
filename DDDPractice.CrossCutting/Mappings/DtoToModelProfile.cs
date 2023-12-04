using AutoMapper;
using DDDPractice.Domain.Models;
using DDDPractice.Domain.DTOs.User;

namespace DDDPractice.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}