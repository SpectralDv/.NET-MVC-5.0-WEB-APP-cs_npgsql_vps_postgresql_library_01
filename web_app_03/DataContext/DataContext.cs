


using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using web_app_03.Interface;
using web_app_03.Models;

namespace web_app_03.DataContext
{
    public class DataContext : IContextBook,IContextClient
    {
        private DbConnection db;
        private DataTable dataTable;
        private bool isFind;

        public DataContext() { }

        public DataTable getDataTable() { return dataTable; }
        public bool getIsFind() { return isFind; }

        public void CommandConnection(NpgsqlCommand command)
        {
            NpgsqlDataReader ndr = command.ExecuteReader();

            //dataTable = new DataTable();

            //Int32 rowsAffected;
            //Console.WriteLine("BookContext");

            if (ndr.HasRows)
            {
                dataTable = new DataTable();
                dataTable.Load(ndr);
            }

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
        ////////////////////////////////////////////////////////////////////////////////////
        public NpgsqlCommand Insert(EditModel editModel, string p1, string p2)
        {
            db = new DbConnection();
            db.openConnection();

            //"INSERT INTO users(login,pass) VALUES (@p1,@p2)";
            string query = "INSERT INTO "+editModel.NameTable+"("+editModel.NameCol1 +","+editModel.NameCol2+") VALUES (@p1,@p2)";
            //string query = "insert into users(login,pass) values('" + p1 + "','12345678')";
            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                    new("p2", p2),
                }
            };
            return command;
        }
        public NpgsqlCommand Insert(EditModel editModel,string p1, string p2, int p3)
        {
            db = new DbConnection();
            db.openConnection();

            //string col2 = "name";//$"{((IName)im).GetType().Name}";
            //"INSERT INTO book(name,description,status) VALUES (@p1,@p2,@p3)";
            string query = "INSERT INTO "+ editModel.NameTable + "("
                                         + editModel.NameCol1 + ","
                                         + editModel.NameCol2 + ","
                                         + editModel.NameCol3 + ") VALUES (@p1,@p2,@p3)";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                    new("p2", p2),
                    new("p3", p3),
                }
            };
            return command;
        }
        /////////////////////////////////////////////////////////////////////////////////////
        public NpgsqlCommand Select(string nameTable)
        {
            db = new DbConnection();
            db.openConnection();

            string query = "select * from " + nameTable;

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection());

            return command;
        }
        public NpgsqlCommand Find(string nameTable,string nameCol,int p1)
        {
            db = new DbConnection();
            db.openConnection();

            string query = "select * from " + nameTable + " where " + nameCol + " = @p1";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                }
            };

            return command;
        }
        public NpgsqlCommand Find(string nameTable,string nameCol,string p1)
        {
            db = new DbConnection();
            db.openConnection();

            string query = "select * from " + nameTable + " where "+ nameCol + " = @p1";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                }
            };

            return command;
        }
        public NpgsqlCommand Update(string nameTable,string nameCol,string p1,int p2)
        {
            db = new DbConnection();
            db.openConnection();

            //"update book set description = 'dawdawdawdaw' where id = 1";
            string query = "update "+ nameTable + " set "+ nameCol + " = @p1 where id = @p2";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                    new("p2", p2),
                }
            };

            return command;
        }
        public NpgsqlCommand Update(string nameTable,string nameCol,int p1,int p2)
        {
            db = new DbConnection();
            db.openConnection();

            //"update book set description = 'dawdawdawdaw' where id = 1";
            string query = "update " + nameTable + " set " + nameCol + " = @p1 where id = @p2";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                    new("p2", p2),
                }
            };

            return command;
        }
        public NpgsqlCommand Delete(string nameTable, int p1)
        {
            db = new DbConnection();
            db.openConnection();

            //"delete from book where id = 1";
            string query = "delete from " + nameTable + " where id = @p1";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                }
            };

            return command;
        }
        public NpgsqlCommand Delete(string nameTable, string nameCol, string p1)
        {
            db = new DbConnection();
            db.openConnection();

            //"delete from users where login = '" + stringLogin + "'"
            string query = "delete from " + nameTable + " where "+ nameCol + " = @p1";

            NpgsqlCommand command = new NpgsqlCommand(query, db.getConnection())
            {
                Parameters =
                {
                    new("p1", p1),
                }
            };

            return command;
        }
        ////////////////////////////////////////////////////////////////////
        public void EditText(IContext context,EditModel editModel)
        {
            context.CommandConnection(context.Find(editModel.NameTable,editModel.FindCol, editModel.FindText));

            if (context.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = context.getDataTable();

                //var listBookModel = new List<BookModel>();
                //var oneBookModel = new BookModel();
                var count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    //"update book set description = 'dawdawdawdaw' where id = 1";
                    context.CommandConnection(context.Update(editModel.NameTable, editModel.NameCol1, editModel.EditText, (int)dt.Rows[i][0]));
                }
            }
        }
        public void EditValue(IContext context, EditModel editModel)
        { 
            context.CommandConnection(context.Find(editModel.NameTable,editModel.FindCol, editModel.FindText));

            if (context.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = context.getDataTable();

                //var listBookModel = new List<BookModel>();
                //var oneBookModel = new BookModel();
                var count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    context.CommandConnection(context.Update(editModel.NameTable, editModel.NameCol1, editModel.EditValue, (int)dt.Rows[i][0]));
                }
            }
        }
        public void Delete(IContext context, EditModel editModel)
        {
            context.CommandConnection(context.Find(editModel.NameTable, editModel.FindCol, editModel.FindText));

            if (context.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = context.getDataTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine((int)dt.Rows[i][0]);
                    //check id
                    if ((int)dt.Rows[i][0] == editModel.FindValue)
                    {
                        context.CommandConnection(context.Delete(editModel.NameTable, editModel.FindValue));
                    }
                }
            }
        }
        public void DeleteCol(IContext context, EditModel editModel)
        {
            context.CommandConnection(context.Find(editModel.NameTable, editModel.FindCol, editModel.FindText));

            if (context.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = context.getDataTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine((int)dt.Rows[i][0]);
                    //check id
                    //if ((int)dt.Rows[i][0] == editModel.FindValue)
                    //{
                        //Delete(string nameTable, string nameCol, string p1)
                        context.CommandConnection(context.Delete(editModel.NameTable, editModel.NameCol1, editModel.FindText));
                    //}
                }
            }
        }
    }; 
}