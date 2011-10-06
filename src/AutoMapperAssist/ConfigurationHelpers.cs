using AutoMapper;
using AutoMapper.Mappers;

namespace AutoMapperAssist
{
    public static class ConfigurationHelpers
    {
        public static ConfigurationStore CreateDefaultConfiguration()
        {
            return new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers());
        }
    }
}