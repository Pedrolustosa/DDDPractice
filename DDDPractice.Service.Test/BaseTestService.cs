using AutoMapper;
using DDDPractice.CrossCutting.Mappings;

namespace DDDPractice.Service.Test;

public abstract class BaseTestService
{
    public IMapper IMapper {get; set;}

    public BaseTestService()
    {
        IMapper = new AutoMapperFixture().GetMapper();
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });
            return config.CreateMapper();
        }
        
        #pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
        {

        }
    }
}