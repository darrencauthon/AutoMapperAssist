namespace AutoMapperAssist
{
    public static class TestingHelpers
    {
        public static void AssertConfigurationIsValid(this IMapToDefine mapToDefine)
        {
            var configuration = ConfigurationHelpers.CreateDefaultConfiguration();
            mapToDefine.DefineMap(configuration);
            configuration.AssertConfigurationIsValid();
        }
    }
}