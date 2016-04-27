using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_MVC_Lab2.Models
{
    public class dbModel
    {
        public void Insert(string action, string parameter)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SPARK-ПК;Initial Catalog=IntProgrLog;Integrated Security=True"))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO TableLog (Action, Parameter) VALUES (@action, @parameter)";
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@parameter", parameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {

                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}