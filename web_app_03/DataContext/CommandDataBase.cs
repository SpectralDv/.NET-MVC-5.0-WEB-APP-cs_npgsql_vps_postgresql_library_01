using Npgsql;
using System;
using System.Data;

namespace web_app_03.DataContext
{
    public class CommandDataBase
    {
        private DbConnection db;
        private DataTable dataTable;
        private bool isFind;

        public CommandDataBase(string stringCommand)
        {
            db = new DbConnection();

            db.openConnection();

            NpgsqlCommand command = new NpgsqlCommand();

            command.Connection = db.getConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = stringCommand;

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