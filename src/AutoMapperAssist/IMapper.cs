using System.Collections.Generic;

namespace AutoMapperAssist
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination CreateInstance(TSource source);
        IEnumerable<TDestination> CreateSet(IEnumerable<TSource> source);
        void LoadIntoInstance(TSource source, TDestination destination);
    }
}