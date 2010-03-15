using AutoMapper;

namespace AutoMapperAssist
{
    public interface IMapToDefine
    {
        void DefineMap(IConfiguration configuration);
        void DefineMap<TSource, TDestination>(IConfiguration configuration, IMappingExpression<TSource, TDestination> map);
    }
}