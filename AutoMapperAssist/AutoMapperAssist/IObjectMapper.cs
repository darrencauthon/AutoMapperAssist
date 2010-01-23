namespace AutoMapperAssist
{
    public interface IObjectMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);
    }
}