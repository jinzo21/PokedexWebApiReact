using PokedexWebApiReact.Models.Domains;
using PokedexWebApiReact.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokedexWebApiReact.Controllers
{
    public class PokedexController : ApiController
    {
        readonly IPokedexService pokedexService;

        public PokedexController(IPokedexService pokedexService)
        {
            this.pokedexService = pokedexService;
        }

        //SCRAPE 151 POKEMON
        [Route("scraper/151"), HttpPost]
        public object ScrapeInsertPokemon()
        {

            pokedexService.ScrapeInsertPokemon();

            //Create Model to check Pokemon Data is Correct
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //GetAll
        [Route("pokemon"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<Pokemon> pokemon = pokedexService.GetAllWrap();

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);

            }

            return Request.CreateResponse(HttpStatusCode.OK, pokemon);

        }

        //GetByName
        [Route("pokemon/{pokemonName}"), HttpGet]
        public HttpResponseMessage GetByName(string pokemonName)
        {
            Pokemon pokemon = pokedexService.GetByName(pokemonName);

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pokemon);

        }
    }
}