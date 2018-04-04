using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    public class DataWrapper
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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = sqlQuery;

                if (parametersCallback != null)
                {
                    parametersCallback(cmd);
                }

                if (rowCallback != null)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<Pokemon>();

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
