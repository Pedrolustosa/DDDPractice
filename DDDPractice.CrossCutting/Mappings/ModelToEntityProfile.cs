using AutoMapper;
using DDDPractice.Domain.Models;
using DDDPractice.Domain.Entities;

namespace DDDPractice.CrossCutting.Mappings
{
    /// <summary>
    /// The model to entity profile.
    /// </summary>
    public class ModelToEntityProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelToEntityProfile"/> class.
        /// </summary>
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}