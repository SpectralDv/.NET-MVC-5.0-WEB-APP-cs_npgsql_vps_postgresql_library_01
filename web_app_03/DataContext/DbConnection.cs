using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using web_app_03.Models;

namespace web_app_03.DataContext
{
    public class DbConnection
    {
        NpgsqlConnection connection = new NpgsqlConnection("Server=0.00.00.000;Port=5432;User Id=user;Password=12345678;Database=librarydb;");

        //public DbSet<ClientModel> ClientObj { get; set; }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public NpgsqlConnection getConnection() { return connection; }

        //public virtual DbSet { get; set; }
    };
}
