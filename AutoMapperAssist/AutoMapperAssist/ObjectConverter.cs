using AutoMapper;

namespace AutoMapperAssist
{
    public class ObjectConverter<TFrom, TTo>
    {
        private readonly IMappingEngine mappingEngine;

        public ObjectConverter(IMappingEngine mappingEngine)
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