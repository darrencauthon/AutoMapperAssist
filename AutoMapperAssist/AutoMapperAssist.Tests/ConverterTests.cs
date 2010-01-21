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

            var mappingEngineFake = new Mock<IMappingEngine>();
            mappingEngineFake.Setup(x => x.Map<Apple, Orange>(apple))
                .Returns(expectedOrange);

            var converter = new TestObjectConverter(mappingEngineFake.Object);

            // act
            var orange = converter.Convert(apple);

            // assert
            Assert.AreSame(expectedOrange, orange);
        }

        [TestMethod]
        public void CreateMap_PassedMappingConfiguration_CallsCreateMapOnMappingConfiguration()
        {
            // arrange
            var converter = new TestObjectConverter(new Mock<IMappingEngine>().Object);

            var configurationFake = new Mock<IConfiguration>();

            // act
            converter.CreateMap(configurationFake.Object);

            // assert
            configurationFake.Verify(x => x.CreateMap<Apple, Orange>(), Times.Once());
        }
    }

    public class TestObjectConverter : ObjectConverter<Apple, Orange>
    {
        public TestObjectConverter(IMappingEngine mappingEngine)
            : base(mappingEngine){}
    }

    public class Apple
    {
    }

    public class Orange
    {
    }
}