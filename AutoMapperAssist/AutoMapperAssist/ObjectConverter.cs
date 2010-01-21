using AutoMapper;

namespace AutoMapperAssist
{
    public abstract class ObjectConverter<TFrom, TTo> : IMapToCreate
    {
        private readonly IMappingEngine mappingEngine;

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
    }
}