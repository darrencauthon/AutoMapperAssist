using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoMapperAssist.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void Convert_PassedT_ReturnsResultFromAutoMapper()
        {
            // arrange
            var expectedOrange = new Orange();

            var apple = new Apple();

            var mappingEngine = new Mock<IMappingEngine>();
            mappingEngine.Setup(x => x.Map<Apple, Orange>(apple))
                .Returns(expectedOrange);

            var converter = new ObjectConverter<Apple, Orange>(mappingEngine.Object);

            // act
            var orange = converter.Convert(apple);

            // assert
            Assert.AreSame(expectedOrange, orange);
        }
    }

    public class Apple
    {
    }

    public class Orange
    {
    }
}