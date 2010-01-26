using System.Collections.Generic;

namespace AutoMapperAssist
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        IEnumerable<TDestination> Map(IEnumerable<TSource> source);
        void Map(TSource source, TDestination destination);
    }
}