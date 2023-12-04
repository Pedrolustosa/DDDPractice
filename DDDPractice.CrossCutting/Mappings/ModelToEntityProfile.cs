using AutoMapper;
using DDDPractice.Domain.Models;
using DDDPractice.Domain.Entities;

namespace DDDPractice.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}