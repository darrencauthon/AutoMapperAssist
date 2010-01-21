using AutoMapper;
using AutoMapper.Mappers;

namespace AutoMapperAssist
{
    public abstract class ObjectConverter<TFrom, TTo> : IMapToCreate
    {
        private readonly IMappingEngine mappingEngine;

        protected ObjectConverter()
        {
            var configuration = CreateAutoMapperConfigurationWithCurrentMap();
            mappingEngine = new MappingEngine(configuration);
        }

        private static Configuration CreateDefaultAutoMapperConfiguration()
        {
            return new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
        }

        protected ObjectConverter(IMappingEngine mappingEngine)
        {
            this.mappingEngine = mappingEngine;
        }

        public virtual TTo Convert(TFrom from)
        {
            return mappingEngine.Map<TFrom, TTo>(from);
        }

        public virtual void CreateMap(IConfiguration configuration)
        {
            configuration.CreateMap<TFrom, TTo>();
        }

        #region private methods

        private Configuration CreateAutoMapperConfigurationWithCurrentMap()
        {
            var configuration = CreateDefaultAutoMapperConfiguration();
            CreateMap(configuration);
            return configuration;
        }

        #endregion
    }
}