using AutoMapper;
using DDDPractice.Domain.Models;
using DDDPractice.Domain.DTOs.User;

namespace DDDPractice.CrossCutting.Mappings
{
    /// <summary>
    /// The dto to model profile.
    /// </summary>
    public class DtoToModelProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoToModelProfile"/> class.
        /// </summary>
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}