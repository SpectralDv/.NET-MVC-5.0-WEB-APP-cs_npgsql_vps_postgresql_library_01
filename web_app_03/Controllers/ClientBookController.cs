using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using web_app_03.Models;
using web_app_03.DataContext;
using Npgsql;

namespace web_app_03.Controllers
{
    public class ClientBookController : Controller
    {
        public ClientBookController()
        {

        }
        public IActionResult IndexClientBook()
        {
            return View();
        }
        public IActionResult TableClientBook()
        {
            //string str = "select * from " + "usersbook";
            //CommandDataBase cdb = new CommandDataBase(str);
            //DataTable dt = cdb.getDataTable();

            string strTab = "select ub.*, b.name, u.login from usersbook ub " +
                            "left join book b on b.id=ub.idbook left join users u on u.id=ub.iduser ;";
            CommandDataBase cdbTab = new CommandDataBase(strTab);
            DataTable dtTab = cdbTab.getDataTable();

            var listClientBookModel = new List<ClientBookModel>();
            //var count = dt.Rows.Count;

            if (cdbTab.getIsFind() == true)
            {
                for (int i = 0; i < dtTab.Rows.Count; i++)
                {
                    listClientBookModel.Add(new ClientBookModel
                    {
                        Id = (int)dtTab.Rows[i][0],
                        IdBook = (int)dtTab.Rows[i][1],
                        IdClient = (int)dtTab.Rows[i][2],
                        NameBook = (string)dtTab.Rows[i][3],
                        NameClient = (string)dtTab.Rows[i][4],
                    });
                }
            }

            return View(listClientBookModel);
        }
        public IActionResult GetBook()
        {
            return View();
        }
        public IActionResult FormGetBook(string nameBook, string nameClient)
        {
            var clientModel = new ClientModel();
            var bookModel = new BookModel();

            //find client with name in TableClient
            string strFindClient = "select * from users where login = ";
            FindDataBase fdbClient = new FindDataBase(strFindClient, nameClient);

            if (fdbClient.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = fdbClient.getDataTable();

                var count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    clientModel.Id = (int)dt.Rows[i][0];
                    clientModel.Login = (string)dt.Rows[i][1];
                    //Console.WriteLine(clientModel.Login);
                    break;
                }
            }
            else { return RedirectToAction("IndexClientBook"); }

            //find books with name in TableBook
            string strFindBook = "select * from book where name = ";
            FindDataBase fdbBook = new FindDataBase(strFindBook, nameBook);

            if (fdbBook.getIsFind() == true)
            {
                DataTable dt = new DataTable();
                dt = fdbBook.getDataTable();

                var count = dt.Rows.Count;
                //Console.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    //check status book
                    if ((int)dt.Rows[i][3] == 1)
                    {
                        bookModel.Id = (int)dt.Rows[i][0];
                        bookModel.Name = (string)dt.Rows[i][1];
                        bookModel.Description = (string)dt.Rows[i][2];
                        bookModel.Status = 0;  //edit status

                        //edit status book in TableBook
                        string strEdit = "update book set status ='" + bookModel.Status + "' where id = " + bookModel.Id;
                        CommandDataBase cdbEdit = new CommandDataBase(strEdit);

                        //Console.WriteLine(clientModel.Login);

                        //create new row in TableClientBook
                        string strAdd = "insert into usersbook(idbook,iduser) values(" + bookModel.Id + "," + clientModel.Id + ")";
                        CommandDataBase cdb = new CommandDataBase(strAdd);


                        return RedirectToAction("TableClientBook");
                    }
                }
                return RedirectToAction("TableClientBook");
            }
            return RedirectToAction("IndexClientBook"); 
        }
        public IActionResult SetBook()
        {
            return View();
        }
        public IActionResult FormSetBook(string nameBook, string nameClient)
        {
            var clientModel = new ClientModel();
            var listClientBookModel = new List<ClientBookModel>();
            var bookModel = new BookModel();

            DataTable dtClient;
            DataTable dt;
            DataTable dtBook;
            var count = 0;
            var countClientBook = 0;

            //find client in TableClient
            string commmandFindClient = "select * from users where login = ";
            FindDataBase fdbClient = new FindDataBase(commmandFindClient, nameClient);

            if (fdbClient.getIsFind() == true)
            {
                dtClient = new DataTable();
                dtClient = fdbClient.getDataTable();
                count = dtClient.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    clientModel.Id = (int)dtClient.Rows[i][0];
                    clientModel.Login = (string)dtClient.Rows[i][1];
                    break;
                }
            }
            else { return RedirectToAction("IndexClientBook"); }

            //find idBook(idClient) in TableClientBook
            //string commmandFindClientBook = "select * from usersbook where iduser = ";
            //FindDataBase fdbClientBook = new FindDataBase(commmandFindClientBook, clientModel.Id.ToString());
            string str1 = "select * from usersbook where iduser = " + clientModel.Id;
            CommandDataBase fdbClientBook = new CommandDataBase(str1);

            if (fdbClientBook.getIsFind() == true)
            {
                dt = new DataTable();
                dt = fdbClientBook.getDataTable();
                countClientBook = dt.Rows.Count;
            }
            else { return RedirectToAction("IndexClientBook"); }

            //check nameBook on TableBook
            string commmandFindBook = "select * from book where name = ";
            FindDataBase fdbBook = new FindDataBase(commmandFindBook, nameBook);

            if (fdbBook.getIsFind() == true)
            {
                dtBook = new DataTable();
                dtBook = fdbBook.getDataTable();
                //countBook = dtBook.Rows.Count;

                //check idBook(nameBook) in TableBook
                for (int i = 0; i < countClientBook; i++)
                {
                    if ((int)dtBook.Rows[0][0] == (int)dt.Rows[i][1])
                    {
                        //edit status book in TableBook
                        string str = "update book set status = '1' where id = " + (int)dtBook.Rows[0][0];
                        CommandDataBase cmb = new CommandDataBase(str);

                        string strDelete = "delete from usersbook where id=" + (int)dt.Rows[i][0];
                        CommandDataBase cmbDelete = new CommandDataBase(strDelete);
                    }
                }
                return RedirectToAction("TableClientBook");
            }
            else { return RedirectToAction("IndexClientBook"); }
        }

        public IActionResult DeleteClientBook()
        {
            return View();
        }
        public IActionResult FormDeleteClientBook(string stringIdRow)
        {
            string str = "delete from usersbook where id = '" + stringIdRow + "'";
            CommandDataBase cdb = new CommandDataBase(str);

            return RedirectToAction("IndexClientBook");
        }
    }
}