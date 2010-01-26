using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AutoMapperAssist
{
    public abstract class Mapper<TFrom, TTo> : IMapToDefine, IMapper<TFrom, TTo>
    {
        private readonly IMappingEngine mappingEngine;

        protected Mapper()
        {
            var configuration = CreateAutoMapperConfigurationWithCurrentMap();
            mappingEngine = new MappingEngine(configuration);
        }

        private static Configuration CreateDefaultAutoMapperConfiguration()
        {
            return ConfigurationHelpers.CreateDefaultConfiguration();
        }

        protected Mapper(IMappingEngine mappingEngine)
        {
            this.mappingEngine = mappingEngine;
        }

        public virtual TTo Map(TFrom from)
        {
            return mappingEngine.Map<TFrom, TTo>(from);
        }

        public virtual IEnumerable<TTo> Map(IEnumerable<TFrom> from)
        {
            return from item in @from
                   select mappingEngine.Map<TFrom, TTo>(item);
        }

        public virtual void Map(TFrom from, TTo to)
        {
            mappingEngine.Map(from, to);
        }

        public virtual void DefineMap(IConfiguration configuration)
        {
            configuration.CreateMap<TFrom, TTo>();
        }

        #region private methods

        private Configuration CreateAutoMapperConfigurationWithCurrentMap()
        {
            var configuration = CreateDefaultAutoMapperConfiguration();
            DefineMap(configuration);
            return configuration;
        }

        #endregion
    }
}