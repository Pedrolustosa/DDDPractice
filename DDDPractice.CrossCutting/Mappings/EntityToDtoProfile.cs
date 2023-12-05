using AutoMapper;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.DTOs.User;

namespace DDDPractice.CrossCutting.Mappings
{
    /// <summary>
    /// The entity to dto profile.
    /// </summary>
    public class EntityToDtoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityToDtoProfile"/> class.
        /// </summary>
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}