using System.Collections.Generic;

namespace AutoMapperAssist
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);
        IEnumerable<TTo> Map(IEnumerable<TFrom> from);
        void Map(TFrom from, TTo to);
    }
}