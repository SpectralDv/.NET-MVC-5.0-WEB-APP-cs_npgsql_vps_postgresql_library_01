
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;

namespace web_app_03.DataContext
{
    public class FindDataBase
    {
        private DbConnection db;
        private DataTable dataTable;
        private bool isFind;

        public FindDataBase(string stringCommand,string findName)
        {
            db = new DbConnection();

            db.openConnection();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = db.getConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = stringCommand + "@text";
            command.Parameters.Add("@text", NpgsqlDbType.Varchar).Value = findName;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            dataTable = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                isFind = true;
            }
            else
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
