using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.Api.Controllers;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pokemon.Api.Tests.UnitTests
{
    public class PokemonControllerTests
    {
        [Fact]
        public async Task Should_Return_Pokemon()
        {
            //Arrange
            var mockPokemonService = new Mock<IPokemonService>();
            mockPokemonService.Setup(serv => serv.GetPokemon("ditto"))
                .ReturnsAsync(PokemonJsonObj);

            var mockTranslatePokemon = new Mock<ITranslatePokemon>();
            var mockLogger = new Mock<ILogger<PokemonController>>();
            var controller = new PokemonController(mockLogger.Object, mockPokemonService.Object, mockTranslatePokemon.Object);

            // Act
            var result = await controller.Get("ditto");
            var okResult = result as ObjectResult;


            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.IsType<Pokemon.Api.Model.Pokemon>(okResult.Value);
            var response = okResult.Value as Pokemon.Api.Model.Pokemon;
            Assert.Equal("ditto for test", response.Name);
            Assert.Equal("desc in english", response.Description);
            Assert.False(response.IsLegendary);
            Assert.Equal("cave", response.Habitat);

        }

        private PokemonJson PokemonJsonObj() => new PokemonJson
        {
            Name = "ditto for test",
            IsLegendary = false,
            Habitat = new Habitat() { Name = "cave" },
            FlavorTextEntries = new List<FlavorTextEntries>()
            {
                new FlavorTextEntries()
                {
                    FlavorText = "desc in english",
                    Language = new Language()
                    {
                        Name = "en"
                    }
                },
                new FlavorTextEntries()
                {
                    FlavorText = "desc in spanish",
                    Language = new Language()
                    {
                        Name = "es"
                    }
                }
            }
        };

    }
}
