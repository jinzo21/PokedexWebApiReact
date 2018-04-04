using PokedexWebApiReact.Models.Domains;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokedexWebApiReact
{
    public class PokedexWrapper
    {
        public static void ExecuteQuery(
            string sqlQuery,
            //Set to Null for flexbility
            Action<SqlDataReader> rowCallback = null,
            Action<SqlCommand> parametersCallback = null
        )
        {
            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PokedexDB"].ConnectionString))
            {
                dbConnection.Open();

                var cmd = dbConnection.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametersCallback != null)
                {
                    parametersCallback(cmd);
                }

                if (rowCallback != null)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rowCallback(reader);
                        }
                    }
                }
                else
                {
                    //Allows us to work with inserts, updates, deletes
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}