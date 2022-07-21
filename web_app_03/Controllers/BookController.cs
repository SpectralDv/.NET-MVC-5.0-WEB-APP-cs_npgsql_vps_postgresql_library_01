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
using web_app_03.Interface;

namespace web_app_03.Controllers
{
    public class BookController : Controller
    {
        public BookController()
        {

        }
        public IActionResult IndexBook()
        {
            return View();
        }
        public IActionResult TableBook()
        {
            DataContext.DataContext bc = new DataContext.DataContext();
            bc.CommandConnection(bc.Select("book"));
            DataTable dt = bc.getDataTable();

            var listBookModel = new List<BookModel>();
            var count = dt.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                listBookModel.Add(new BookModel 
                {   
                    Id = (int)dt.Rows[i][0], 
                    Name = (string)dt.Rows[i][1],
                    Description = (string)dt.Rows[i][2], 
                    Status = (int)dt.Rows[i][3] 
                });
            }

            return View(listBookModel);
        }
        public IActionResult AddBook()
        {
            return View();
        }
        public IActionResult FormAddBook(string strBookName, string strDescription)
        {
            EditModel eml = new EditModel();
            eml.NameTable = "book";
            eml.NameCol1 = "name";
            eml.NameCol2 = "description";
            eml.NameCol3 = "status";

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.CommandConnection(bct.Insert(eml,strBookName, strDescription, 1));

            return RedirectToAction("TableBook");
        }
        public IActionResult EditDescriptionBook()
        {
            return View();
        }
        public IActionResult FormEditDescriptionBook(string strBookName,string strDescription)
        {
            EditModel eml = new EditModel();
            eml.NameTable = "book";
            eml.FindCol = "name";
            eml.NameCol1 = "description";
            eml.FindText = strBookName;
            eml.EditText = strDescription;

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.EditText(bct, eml);

            return RedirectToAction("TableBook");
        }
        public IActionResult EditStatusBook()
        {
            return View();
        }
        public IActionResult FormEditStatusBook(string strBookName, int intStatus)
        {
            EditModel eml = new EditModel();
            eml.NameTable = "book";
            eml.FindCol = "name";
            eml.NameCol1 = "status";
            eml.FindText = strBookName;
            eml.EditValue = intStatus;

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.EditValue(bct, eml);

            return RedirectToAction("TableBook");
        }
        public IActionResult DeleteBook()
        {
            return View();
        }
        public IActionResult FormDeleteBook(int intIdBook, string strBookName)
        {
            EditModel eml = new EditModel();
            eml.NameTable = "book";
            eml.FindCol = "name";
            eml.FindValue = intIdBook;
            eml.FindText = strBookName;

            DataContext.DataContext bct = new DataContext.DataContext();
            bct.Delete(bct,eml);

            return RedirectToAction("TableBook");
        }
    }
}
