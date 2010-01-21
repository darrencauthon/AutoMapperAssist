namespace AutoMapperAssist
{
    public interface IObjectConverter<TFrom, TTo>
    {
        TTo Convert(TFrom from);
    }
}