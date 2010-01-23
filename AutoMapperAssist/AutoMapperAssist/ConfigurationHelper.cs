using AutoMapper;
using AutoMapper.Mappers;

namespace AutoMapperAssist
{
    public static class ConfigurationHelper
    {
        public static Configuration CreateDefaultConfiguration()
        {
            return new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
        }
    }
}