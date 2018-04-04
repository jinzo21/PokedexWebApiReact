using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokedexWebApiReact.Controllers;
using PokedexWebApiReact.Models.Domains;
using PokedexWebApiReact.Services;

namespace PokedexTests
{
    [TestClass]
    public class PokedexTest
    {
        [TestMethod]
        public void TestGetAllService()
        {
            var pokedexService = new PokedexService();
            var response = pokedexService.GetAll();

            Assert.IsTrue(response.Count > 0, "should have at least 1 pokemon");
        }

        [TestMethod]
        public void TestGetByNameService()
        {
            //Arrange
            var samplePokemon = new Pokemon();
            samplePokemon.Id = 12;
            samplePokemon.PokemonId = "#123";
            samplePokemon.PokemonName = "Stevo-O";
            samplePokemon.PokemonDescription = "Agile under extreme stress";
            samplePokemon.PokemonHeight = "6'";
            samplePokemon.PokemonWeight = "210 LBs";
            samplePokemon.PokemonType = "Jackass";
            samplePokemon.PokemonImage = "https://i.imgur.com/XCuRbHC.jpg";
            samplePokemon.PokemonImageSFront = "https://i.imgur.com/XCuRbHC.jpg";
            samplePokemon.PokemonImageSBack = "https://i.imgur.com/XCuRbHC.jpg";
            samplePokemon.StatHp = "200";
            samplePokemon.StatAttack = "10";
            samplePokemon.StatDefense = "120";
            samplePokemon.StatSpAttack = "30";
            samplePokemon.StatSpDefense = "120";
            samplePokemon.StatSpeed = "80";
            samplePokemon.StatTotal = "560";

            //Create Mock service to serve up sample data
            var mock = new Mock<IPokedexService>();
            mock.Setup(m => m.GetByName(samplePokemon.PokemonName)).Returns(samplePokemon);

            //ACT
            var mockService = mock.Object;
            var response = mockService.GetByName(samplePokemon.PokemonName);

            //Assert
            Assert.IsTrue(response.PokemonName == "Stevo-O");
            Assert.IsTrue(response.PokemonId == "#123");
            Assert.IsTrue(response.PokemonImage == "https://i.imgur.com/XCuRbHC.jpg");
            Assert.IsTrue(response.StatTotal == "560");            
        }

        [TestMethod]
        public void TestGetAllController()
        {
            //Arrange
            var samplePokemon = new List<Pokemon>();
            samplePokemon.Add(new Pokemon
            {
                Id = 12,
                PokemonId = "#123",
                PokemonName = "Stevo-O",
                PokemonDescription = "Agile under extreme stress",
                PokemonHeight = "6'",
                PokemonWeight = "210 LBs",
                PokemonType = "Jackass",
                PokemonImage = "https://i.imgur.com/XCuRbHC.jpg",
                PokemonImageSFront = "https://i.imgur.com/XCuRbHC.jpg",
                PokemonImageSBack = "https://i.imgur.com/XCuRbHC.jpg",
                StatHp = "200",
                StatAttack = "10",
                StatDefense = "120",
                StatSpAttack = "30",
                StatSpDefense = "120",
                StatSpeed = "80",
                StatTotal = "560"
            });

            var mock = new Mock<IPokedexService>();
            mock.Setup(m => m.GetAll()).Returns(samplePokemon);

            var mockService = mock.Object;
            var pokedexController = new PokedexController(mockService);

            pokedexController.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };

            //Act
            var response = pokedexController.GetAll();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
