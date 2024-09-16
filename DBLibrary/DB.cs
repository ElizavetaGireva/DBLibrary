using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DBLibrary
{
    internal class DB
    {
        NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;");

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public NpgsqlConnection GetConnection()
        {
            return connection;
        }
    }
}
