using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace container //namespace 
{
    public class DBConnection
    {
        public void ConnectToDatabaseToGetData()
        {
            string connectionstring = "Server=DESKTOP-MD4N5AM;Database=StallionsDB;Integrated Security=True;";


            //now we will create a connection object

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully");

                    //now lets write a sql query to execute using SqlCommand

                    string query = "Select * FROM Employees";

                    SqlCommand command = new SqlCommand(query, connection);

                    //now as we need to read data, we will use sqlreader

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string rowstring = "";
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowstring += reader[i];
                            }
                            Console.WriteLine(rowstring.Trim()); //trim is used to remove trailing spaces from the end of the string
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured" + ex.Message);
                }
                finally //the final block always executes
                {
                    connection.Close();
                    Console.WriteLine("Connection closed");
                }
            }
        }
    }
}
