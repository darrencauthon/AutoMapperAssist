using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoMapperAssist.Tests
{
    [TestClass]
    public class MapperTests
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

            var converter = new TestObjectMapper(mappingEngineFake.Object);

            // act
            var orange = converter.Map(apple);

            // assert
            Assert.AreSame(expectedOrange, orange);
        }

        [TestMethod]
        public void Convert_PassedTAndNoConstructor_ReturnsMappedObject()
        {
            // arrange
            var converter = new TestObjectMapper();

            // act
            var orange = converter.Map(new Apple {Type = "TEST"});

            // assert
            Assert.AreEqual("TEST", orange.Type);
        }

        [TestMethod]
        public void CreateMap_PassedMappingConfiguration_CallsCreateMapOnMappingConfiguration()
        {
            // arrange
            var converter = new TestObjectMapper(new Mock<IMappingEngine>().Object);

            var configurationFake = new Mock<IConfiguration>();

            // act
            converter.DefineMap(configurationFake.Object);

            // assert
            configurationFake.Verify(x => x.CreateMap<Apple, Orange>(), Times.Once());
        }
    }

    public class TestObjectMapper : Mapper<Apple, Orange>
    {
        public TestObjectMapper()
        {
        }

        public TestObjectMapper(IMappingEngine mappingEngine)
            : base(mappingEngine)
        {
        }
    }

    public class Apple
    {
        public string Type { get; set; }
    }

    public class Orange
    {
        public string Type { get; set; }
    }
}