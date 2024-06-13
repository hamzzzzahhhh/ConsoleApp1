using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace container
{
    public class DBConnectionDeleteData
    {
        public void DeleteData()
        {
            string connectionstring = "Server=DESKTOP-MD4N5AM;Database=StallionsDB;Integrated Security=True;";

            //now we will create a connection object

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string FirstNameofEmployee = "Ayyan";

                    string query = "DELETE FROM EMPLOYEES WHERE FirstName = @FirstName";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Firstname", FirstNameofEmployee);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Record deleted successfully");
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