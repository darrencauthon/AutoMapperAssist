using AutoMapper;
using NUnit.Framework;

namespace AutoMapperAssist.Tests
{
    [TestFixture]
    public class TestingHelpersTests
    {
        [Test]
        public void AssertConfigurationIsValid_PassedInvalidMapper_ThrowsException()
        {
            var threwException = false;
            try
            {
                (new InvalidObjectMapper()).AssertConfigurationIsValid();
            } catch
            {
                threwException = true;
            }
            Assert.IsTrue(threwException);
        }

        [Test]
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