using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AutoMapperAssist
{
    public abstract class Mapper<TSource, TDestination> : IMapToDefine, IMapper<TSource, TDestination>
    {
        private readonly IMappingEngine mappingEngine;

        protected Mapper()
        {
            var configuration = CreateAutoMapperConfigurationWithCurrentMap();
            mappingEngine = new MappingEngine(configuration);
        }

        protected Mapper(IMappingEngine mappingEngine)
        {
            this.mappingEngine = mappingEngine;
        }

        protected Mapper(IConfigurationProvider configuration)
        {
            mappingEngine = new MappingEngine(configuration);
        }

        public virtual TDestination Map(TSource source)
        {
            return mappingEngine.Map<TSource, TDestination>(source);
        }

        public virtual IEnumerable<TDestination> Map(IEnumerable<TSource> source)
        {
            return from item in source
                   select mappingEngine.Map<TSource, TDestination>(item);
        }

        public virtual void Map(TSource source, TDestination destination)
        {
            mappingEngine.Map(source, destination);
        }

        public virtual void DefineMap(IConfiguration configuration)
        {
            configuration.CreateMap<TSource, TDestination>();
        }

        #region private methods

        private static Configuration CreateDefaultAutoMapperConfiguration()
        {
            return ConfigurationHelpers.CreateDefaultConfiguration();
        }

        private Configuration CreateAutoMapperConfigurationWithCurrentMap()
        {
            var configuration = CreateDefaultAutoMapperConfiguration();
            DefineMap(configuration);
            return configuration;
        }

        #endregion
    }
}