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

namespace web_app_03.Controllers
{
    public class ClientController : Controller
    {
        
        public ClientController()
        {

        }
        public IActionResult IndexClient()
        {
            return View();
        }
        public IActionResult TableClient()
        {
            DataContext.DataContext bc = new DataContext.DataContext();
            bc.CommandConnection(bc.Select("users"));
            DataTable dt = bc.getDataTable();

            var listClientModel = new List<ClientModel>();
            var count = dt.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                listClientModel.Add(new ClientModel { Id = (int)dt.Rows[i][0], Login = (string)dt.Rows[i][1] });
            }

            return View(listClientModel);
        }
        public IActionResult AddClient()
        {
            return View();
        }
        public IActionResult FormAddClient(string strLogin)
        {
            //string str = "insert into users(login,pass) values('" + strLogin + "','12345678')";
            //CommandDataBase cdb = new CommandDataBase(str);

            EditModel eml = new EditModel();
            eml.NameTable = "users";
            eml.NameCol1 = "login";
            eml.NameCol2 = "pass";

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.CommandConnection(bct.Insert(eml, strLogin, "12345678"));

            return RedirectToAction("TableClient");
        }
        public IActionResult EditClient()
        {
            return View();
        }
        public IActionResult DeleteClient()
        {
            return View();
        }
        public IActionResult FormDeleteClient(string strLogin)
        {
            //string str = "delete from users where login = '" + strLogin + "'";
            //CommandDataBase cdb = new CommandDataBase(str);

            EditModel eml = new EditModel();
            eml.NameTable = "users";
            eml.FindCol = "login";
            eml.NameCol1 = "login";
            //eml.FindValue = intIdClient;
            eml.FindText = strLogin;

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.DeleteCol(bct, eml);

            return RedirectToAction("TableClient");
        }
    }
}
