using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoMapperAssist.Tests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void Map_PassedT_ReturnsResultFromAutoMapper()
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
        public void Map_PassedTAndNoConstructor_ReturnsMappedObject()
        {
            // arrange
            var converter = new TestObjectMapper();

            // act
            var orange = converter.Map(new Apple {Type = "TEST"});

            // assert
            Assert.AreEqual("TEST", orange.Type);
        }

        [TestMethod]
        public void Map_PassedTAndMappingConfigurationInConstructor_ReturnsMappedObject()
        {
            // arrange

            var mappingConfiguration = ConfigurationHelpers.CreateDefaultConfiguration();
            mappingConfiguration.CreateMap<Apple, Orange>();

            var converter = new TestObjectMapper(mappingConfiguration);

            // act
            var orange = converter.Map(new Apple {Type = "TEST"});

            // assert
            Assert.AreEqual("TEST", orange.Type);
        }

        [TestMethod]
        public void Map_PassedEnumerableT_ReturnsEnumerableFromAutoMapper()
        {
            // arrange
            var mappingEngineFake = new Mock<IMappingEngine>();
            mappingEngineFake.Setup(x => x.Map<Apple, Orange>(It.IsAny<Apple>()))
                .Returns(new Orange());

            var converter = new TestObjectMapper(mappingEngineFake.Object);

            // act
            var oranges = converter.Map(new[] {new Apple(), new Apple(), new Apple()});

            // assert
            Assert.AreEqual(3, oranges.Count());
        }

        [TestMethod]
        public void Map_PassedTAndOutVariable_SetsOutValueToMappedResult()
        {
            // arrange
            var expectedOrange = new Orange();

            var apple = new Apple();
            var orange = new Orange();

            var mappingEngineFake = new Mock<IMappingEngine>();

            var converter = new TestObjectMapper(mappingEngineFake.Object);

            // act
            converter.Map(apple, orange);

            // assert
            mappingEngineFake.Verify(x => x.Map(apple, orange), Times.Once());
        }

        [TestMethod]
        public void DefineMap_PassedMappingConfiguration_CallsCreateMapOnMappingConfiguration()
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

        public TestObjectMapper(IConfigurationProvider configurationProvider)
            : base(configurationProvider)
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