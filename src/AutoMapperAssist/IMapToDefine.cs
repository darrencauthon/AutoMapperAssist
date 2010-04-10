using AutoMapper;

namespace AutoMapperAssist
{
    public interface IMapToDefine<TSource, TDestination> : IMapToDefine
    {
        void DefineMap(IMappingExpression<TSource, TDestination> map);
    }

    public interface IMapToDefine
    {
        void DefineMap(IConfiguration configuration);
    }
}