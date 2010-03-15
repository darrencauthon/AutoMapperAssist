using AutoMapper;
using AutoMapper.Mappers;

namespace AutoMapperAssist
{
    public static class ConfigurationHelpers
    {
        public static Configuration CreateDefaultConfiguration()
        {
            return new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
        }
    }
}