using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace container //namespace 
{
    public class DBConnection1
    {
        public void ConnectToDatabaseToPostData()
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

                    //lets create some data to insert into the Employees Table

                    string EmployeeID = "1";
                    string FirstName = "Hamza";
                    string LastName = "Ahmad";
                    string Position = "Employee";

                    string query = "INSERT INTO EMPLOYEES (EmployeeID, FirstName, LastName, Position) VALUES (@EmployeeID, @FirstName, @LastName, @Position)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Position", Position);


                    //now we need to post data

                    int rowsaffected = command.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully");
                    }
                    else {
                        Console.WriteLine("Data could not be inserted");
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
