namespace AutoMapperAssist
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);
    }
}