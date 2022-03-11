using DemoWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DemoWebApplication.Controllers {
    public class BooksController : Controller {
        public ActionResult Index(BooksViewModel booksViewModelObj) {
            Books books = new Books();
            books.PageNumber = booksViewModelObj.PageNumber;
            booksViewModelObj.BooksList = books.GetList();
            booksViewModelObj.TotalRecords = books.TotalRecords;

            return View(booksViewModelObj);
        }

        public ActionResult AddBook() {
            BooksViewModel booksViewModelObj = new BooksViewModel();
            booksViewModelObj.BooksPublicationsList = new Books().BookPublicationsGetList();
            booksViewModelObj.BooksCategoriesList = new Books().BookCategoriesGetList();

            return View(booksViewModelObj);
        }

        [HttpGet]
        public ActionResult SearchBook() {
            BooksViewModel booksViewModelObj = new BooksViewModel();
            booksViewModelObj.BooksPublicationsList = new Books().BookPublicationsGetList();
            booksViewModelObj.BooksCategoriesList = new Books().BookCategoriesGetList();

            return View(booksViewModelObj);
        }

        [HttpPost]
        public JsonResult SearchBook(BooksViewModel model) {

            Books bookObj = new Books();
            bookObj.BookName = model.BookName;
            bookObj.BookCategoryId = model.BookCategoryId;
            bookObj.BookPublisherId = model.BookPublisherId;
            bookObj.PageNumber = model.PageNumber;
            bookObj.PageSize = model.PageSize;
            model.BooksList = bookObj.GetList();
            model.TotalRecords = bookObj.TotalRecords;
            model.PageSize = bookObj.PageSize;

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}