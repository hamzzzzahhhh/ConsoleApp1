using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace container
{
    public class DBConnectionPutData
    {
        public void PutData()
        {
            string connectionstring = "Server=DESKTOP-MD4N5AM;Database=StallionsDB;Integrated Security=True;";

            //now we will create a connection object

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string OldName = "HamzaAhmad";
                    string NewName = "Hamza";

                    string query = "UPDATE EMPLOYEES SET FirstName = @newname WHERE FirstName = @oldname";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@newname", NewName);
                    command.Parameters.AddWithValue("@oldname", OldName);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Record updated successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Connection Closed");
                    Console.WriteLine("Connection has been closed");
                }
            }
        }
    }
}