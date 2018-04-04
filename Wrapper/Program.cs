using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new List<Pokemon>();

            DataWrapper.ExecuteQuery(
                "SELECT * FROM pokedex",

                //Callback that receives Parameters
                parametersCallback: (cmd) => 
                {

                },

                //Callback that receives dataReader
                rowCallback: (reader) =>
                {
                    //Should be called once for every row that comes from DB
                    results.Add(new Pokemon
                    {
                        Id = reader.GetInt32(0),
                        PokemonId = reader.GetString(1),
                        PokemonName = reader.GetString(2),
                        PokemonDescription = reader.GetString(3),
                        PokemonHeight = reader.GetString(4),
                        PokemonWeight = reader.GetString(5),
                        PokemonType = reader.GetString(6),
                        PokemonImage = reader.GetString(7),
                        PokemonImageSFront = reader.GetString(8),
                        PokemonImageSBack = reader.GetString(9),
                        StatHp = reader.GetString(10),
                        StatAttack = reader.GetString(11),
                        StatDefense = reader.GetString(12),
                        StatSpAttack = reader.GetString(13),
                        StatSpDefense = reader.GetString(14),
                        StatSpeed = reader.GetString(15),
                        StatTotal = reader.GetString(16)
                    });
                }
            );

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
