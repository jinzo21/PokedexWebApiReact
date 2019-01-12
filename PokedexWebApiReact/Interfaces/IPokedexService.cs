using System.Collections.Generic;
using PokedexWebApiReact.Models.Domains;

namespace PokedexWebApiReact.Services
{
	/// <summary>
	/// IPokedex interface used for dependency injection
	/// </summary>
    public interface IPokedexService
    {
        List<Pokemon> GetAll();
        Pokemon GetByName(string pokemonName);
        void ScrapeInsertPokemon();
        List<Pokemon> GetAllWrap();
    }
}