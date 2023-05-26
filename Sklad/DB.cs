
using System;
using System.Data.SqlClient;
using System.Windows;

namespace Skald
{
    internal class DB
    {

        //Declare a boolean variable called IsConnected and set it to false
        public bool IsConected = false;

        // Create a new SqlConnection object
        public SqlConnection connection = new SqlConnection();

        //Declare a string variable called query
        public string query = "";

        // Create a new SqlCommand object
        SqlCommand command = new SqlCommand();

        // Create a SqlDataReader object
        public SqlDataReader reader = null;



        public DB(string server, string table)
        {
            Connect(server, table);
        }
        //This code establishes a connection to a database.
        public void Connect(string server, string table)
        {
            //Set the connection string to the database
            connection.ConnectionString = $@"Data Source={server};Initial Catalog={table};Integrated Security=True";
            {
                try
                {
                    //Open the connection
                    connection.Open();
                    IsConected = true;

                }
                catch (Exception ex)
                {
                    //Display an error message if the connection fails
                    MessageBox.Show(ex.Message);
                }
            }

        }

        //This code sets a query to be used in a SQL command. 
        public void Set_Quary(string query)
        {
            //Store the query in a variable
            this.query = query;
            //Create a new SQL command using the query and connection
            command = new SqlCommand(this.query, connection);
            //Execute the command and store the results in a reader
            reader = command.ExecuteReader();
        }
    }
}