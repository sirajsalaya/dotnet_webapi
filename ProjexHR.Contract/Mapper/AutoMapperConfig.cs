using AutoMapper;

namespace ProjexHR.Contract;

public class AutoMapperConfig
{
    public static IMapper Configure()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new EntityMapper());
        });

        return mapperConfiguration.CreateMapper();
    }
}