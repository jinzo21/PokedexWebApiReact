using AngleSharp.Parser.Html;
using PokedexWebApiReact.Models.Domains;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace PokedexWebApiReact.Services
{
    public class PokedexService : IPokedexService
    {

        public List<Pokemon> GetAll()
        {
            //Create DB connection string
            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PokedexDB"].ConnectionString))
            {
                //Open string
                dbConnection.Open();

                //Command a StoredProcedure
                var connectionCommand = dbConnection.CreateCommand();
                connectionCommand.CommandText = "pokedex_getAll";
                connectionCommand.CommandType = System.Data.CommandType.StoredProcedure;

                //Execute command & Get resulsts back
                using (SqlDataReader dataReader = connectionCommand.ExecuteReader())
                {
                    //List that will hold data from reader
                    var results = new List<Pokemon>();

                    //Loop through all data & place into List of Pokemon
                    while (dataReader.Read())
                    {
                        results.Add(new Pokemon
                        {
                            Id = dataReader.GetInt32(0),
                            PokemonId = dataReader.GetString(1),
                            PokemonName = dataReader.GetString(2),
                            PokemonDescription = dataReader.GetString(3),
                            PokemonHeight = dataReader.GetString(4),
                            PokemonWeight = dataReader.GetString(5),
                            PokemonType = dataReader.GetString(6),
                            PokemonImage = dataReader.GetString(7),
                            PokemonImageSFront = dataReader.GetString(8),
                            PokemonImageSBack = dataReader.GetString(9),
                            StatHp = dataReader.GetString(10),
                            StatAttack = dataReader.GetString(11),
                            StatDefense = dataReader.GetString(12),
                            StatSpAttack = dataReader.GetString(13),
                            StatSpDefense = dataReader.GetString(14),
                            StatSpeed = dataReader.GetString(15),
                            StatTotal = dataReader.GetString(16)
                        });
                    }
                    return results;
                }
            }
        }

        public Pokemon GetByName(string pokemonName)
        {
            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PokedexDB"].ConnectionString))
            {
                dbConnection.Open();

                var command = dbConnection.CreateCommand();
                command.CommandText = "pokedex_getByName";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Parameter comming in for Pokemon Name
                command.Parameters.AddWithValue("@pokemonName", pokemonName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Pokemon pokemon = new Pokemon();
                    pokemon.Id = reader.GetInt32(0);
                    pokemon.PokemonId = reader.GetString(1);
                    pokemon.PokemonName = reader.GetString(2);
                    pokemon.PokemonDescription = reader.GetString(3);
                    pokemon.PokemonHeight = reader.GetString(4);
                    pokemon.PokemonWeight = reader.GetString(5);
                    pokemon.PokemonType = reader.GetString(6);
                    pokemon.PokemonImage = reader.GetString(7);
                    pokemon.PokemonImageSFront = reader.GetString(8);
                    pokemon.PokemonImageSBack = reader.GetString(9);
                    pokemon.StatHp = reader.GetString(10);
                    pokemon.StatAttack = reader.GetString(11);
                    pokemon.StatDefense = reader.GetString(12);
                    pokemon.StatSpAttack = reader.GetString(13);
                    pokemon.StatSpDefense = reader.GetString(14);
                    pokemon.StatSpeed = reader.GetString(15);
                    pokemon.StatTotal = reader.GetString(16);

                    return pokemon;
                }
            }
        }

        public void ScrapeInsertPokemon()
        {
            //Create new instance of WebClient
            var WebClient = new WebClient();

            //Set HTML = the result of DownloadString
            var html = WebClient.DownloadString("http://pokedream.com/pokedex/pokemon?display=gen1");

            //Parse the data
            var parser = new HtmlParser();
            var document = parser.Parse(html);

            //Select the table which has pokemon data
            var table = document.QuerySelector("tbody");
            var rows = table.QuerySelectorAll("tr");

            foreach (var row in rows)
            {
                var name = row.QuerySelector("td");

                if (name != null)
                {
                    var WebClientTwo = new WebClient();

                    var htmlTwo = WebClientTwo.DownloadString("http://pokedream.com/pokedex/pokemon/" + name.TextContent);

                    var parserTwo = new HtmlParser();
                    var documentTwo = parserTwo.Parse(htmlTwo);

                    //GENERAL POKEMON TABLE
                    var pokemonTable = documentTwo.QuerySelectorAll("tbody")[1];
                    //Pokemon Pic
                    var pokemonTableRowZero = pokemonTable.QuerySelectorAll("tr")[0];
                    var pokemonTableDataZero = pokemonTableRowZero.QuerySelector("#picture");
                    var pokemonImage = pokemonTableDataZero.QuerySelector("img").GetAttribute("src");
                    //Pokemon Name
                    var pokemonName = pokemonTableDataZero.QuerySelector("img").GetAttribute("alt");
                    //Pokemon Id
                    var pokemonId = documentTwo.QuerySelector("h1 span");
                    //Pokemon Type
                    var pokemonTableDataOne = pokemonTableRowZero.QuerySelectorAll("td")[1];
                    var pokemonType = pokemonTableDataOne.QuerySelector("img").GetAttribute("alt");
                    //Pokemon Height
                    var pokemonTableRowTwo = pokemonTable.QuerySelectorAll("tr")[2];
                    var pokemonHeight = pokemonTableRowTwo.QuerySelectorAll("td")[0];
                    //Pokemon Weight
                    var pokemonTableRowThree = pokemonTable.QuerySelectorAll("tr")[3];
                    var pokemonWeight = pokemonTableRowThree.QuerySelectorAll("td")[0];

                    //DISCRIPTION POKEMON TABLE
                    var pokemonTableDisc = documentTwo.QuerySelector("#flavortext");
                    var pokemonTableDiscRowYellow = pokemonTableDisc.QuerySelectorAll("tr")[0];
                    var pokemonDiscription = pokemonTableDiscRowYellow.QuerySelectorAll("td")[1];
             
                    //STATS POKEMON TABLE
                    var pokemonTableStats = documentTwo.QuerySelector("#stats");
                    var pokemonTableStatsRowOne = pokemonTableStats.QuerySelectorAll("tr")[1];
                    var statHp = pokemonTableStatsRowOne.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowTwo = pokemonTableStats.QuerySelectorAll("tr")[2];
                    var statAttack = pokemonTableStatsRowTwo.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowThree = pokemonTableStats.QuerySelectorAll("tr")[3];
                    var statDefense = pokemonTableStatsRowThree.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowFour = pokemonTableStats.QuerySelectorAll("tr")[4];
                    var statSpAttack = pokemonTableStatsRowFour.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowFive = pokemonTableStats.QuerySelectorAll("tr")[5];
                    var statSpDefense = pokemonTableStatsRowFive.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowSix = pokemonTableStats.QuerySelectorAll("tr")[6];
                    var statSpeed = pokemonTableStatsRowSix.QuerySelectorAll("td")[0];
                    var pokemonTableStatsRowSeven = pokemonTableStats.QuerySelectorAll("tr")[7];
                    var statTotal = pokemonTableStatsRowSeven.QuerySelectorAll("td")[0];

                    //PICS POKEMON TABLE
                    var pokemonTableIamges = documentTwo.QuerySelector("#images");
                    var pokemonTableIamgesDataTwo = pokemonTableIamges.QuerySelectorAll("td")[1];
                    var pokemonImageSFront = pokemonTableIamgesDataTwo.QuerySelectorAll("img")[0].GetAttribute("src");
                    var pokemonImageSBack = pokemonTableIamgesDataTwo.QuerySelectorAll("img")[2].GetAttribute("src");

                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PokedexDB"].ConnectionString))
                    {
                        //Create Connection to DB
                        con.Open();

                        //Create Command for Stored Procedure
                        var cmd = con.CreateCommand();
                        cmd.CommandText = "pokedex_scraper_insert";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //Pass Parameter
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId.TextContent);
                        cmd.Parameters.AddWithValue("@pokemonName", pokemonName);
                        cmd.Parameters.AddWithValue("@pokemonDescription", pokemonDiscription.TextContent);
                        cmd.Parameters.AddWithValue("@pokemonHeight", pokemonHeight.TextContent);
                        cmd.Parameters.AddWithValue("@pokemonWeight", pokemonWeight.TextContent);
                        cmd.Parameters.AddWithValue("@pokemonType", pokemonType);
                        cmd.Parameters.AddWithValue("@pokemonImage", pokemonImage);
                        cmd.Parameters.AddWithValue("@pokemonImageSFront", pokemonImageSFront);
                        cmd.Parameters.AddWithValue("@pokemonImageSBack", pokemonImageSBack);
                        cmd.Parameters.AddWithValue("@statHp", statHp.TextContent);
                        cmd.Parameters.AddWithValue("@statAttack", statAttack.TextContent);
                        cmd.Parameters.AddWithValue("@statDefense", statDefense.TextContent);
                        cmd.Parameters.AddWithValue("@statSpAttack", statSpAttack.TextContent);
                        cmd.Parameters.AddWithValue("@statSpDefense", statSpDefense.TextContent);
                        cmd.Parameters.AddWithValue("@statSpeed", statSpeed.TextContent);
                        cmd.Parameters.AddWithValue("@statTotal", statTotal.TextContent);

                        //No Expected Outputs
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //Using Wrapper
        public List<Pokemon> GetAllWrap()
        {
            var results = new List<Pokemon>();

            PokedexWrapper.ExecuteQuery(
                "pokedex_getAll",

                //Callback that receives dataReader
                rowCallback: (reader) =>
                {
                    //Called once for every row that comes from DB
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
            return results;
        }
    }
}