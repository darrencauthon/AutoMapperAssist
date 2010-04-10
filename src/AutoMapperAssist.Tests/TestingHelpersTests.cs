using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperAssist.Tests
{
    [TestClass]
    public class TestingHelpersTests
    {
        [TestMethod]
        [ExpectedException(typeof (AutoMapperConfigurationException))]
        public void AssertConfigurationIsValid_PassedInvalidMapper_ThrowsException()
        {
            (new InvalidObjectMapper()).AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertConfigurationIsValid_PassedValidMapper_DoesNotThrowException()
        {
            (new ValidObjectMapper()).AssertConfigurationIsValid();
        }
    }

    public class ValidObjectMapper : Mapper<IAmLikeAnApple, IAmAlsoLikeAnApple>
    {
    }

    public class InvalidObjectMapper : Mapper<IAmLikeAnApple, IAmLikeAnOrange>
    {
    }

    public class IAmLikeAnApple
    {
        public string Apple { get; set; }
    }

    public class IAmAlsoLikeAnApple
    {
        public string Apple { get; set; }
    }

    public class IAmLikeAnOrange
    {
        public string Orange { get; set; }
    }
}