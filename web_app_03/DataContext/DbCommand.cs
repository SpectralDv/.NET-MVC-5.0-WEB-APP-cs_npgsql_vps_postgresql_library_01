


using Npgsql;
using System;
using System.Data;

namespace web_app_03.DataContext
{
    public class DbCommand
    {
        private DbConnection db;
        private DataTable dataTable;
        private bool isFind;

        public DbCommand() //string stringCommand
        {
            db = new DbConnection();

            db.openConnection();

            //NpgsqlCommand command = new NpgsqlCommand();

            //command.Connection = db.getConnection();
            //command.CommandType = CommandType.Text;
            //command.CommandText = stringCommand;

            //"insert into book(Name,Author,Price) values('Name1','Author1','10')";

            //NpgsqlCommand command = new NpgsqlCommand("INSERT INTO fo(name, description, aa)", db.getConnection());
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO book VALUES (@p1,@p2,@p3)", db.getConnection())
            {
                Parameters =
                {
                    new("p1", "name"),
                    new("p2", "description"),
                    new("p3", 1),
                }
            };


            //string query = string.Format("SELECT dbo.TicketPrice({0},{1},{2})", id_route, d, g);
            //SqlCommand cmd = new SqlCommand(query, con);

            //string query = string.Format("INSERT INTO book",);

            //NpgsqlDataReader reader = command.ExecuteReader();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            //Int32 rowsAffected;
            //Console.WriteLine("CommandDataBase");

            try
            {
                //rowsAffected = command.ExecuteNonQuery();
                isFind = true;
            }
            catch
            {
                isFind = false;
            }

            command.Dispose();
            db.closeConnection();
        }

        public DataTable getDataTable() { return dataTable; }
        public bool getIsFind() { return isFind; }
    };
}