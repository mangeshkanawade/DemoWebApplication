using DemoWebApplication.Models;
using System.Web.Mvc;

namespace DemoWebApplication.Controllers {
    public class BooksController : Controller {
        public ActionResult Index(BooksViewModel booksViewModelObj) {
            Books books = new Books();
            books.PageNumber = booksViewModelObj.PageNumber;
            books.PageSize = booksViewModelObj.PageSize;
            booksViewModelObj.BooksList = books.GetList();
            booksViewModelObj.TotalRecords = books.TotalRecords;
            return View(booksViewModelObj);
        }

        [HttpGet]
        public ActionResult AddBook(Books books) {
            BooksViewModel booksViewModelObj = new BooksViewModel();
            Books bookObj = new Books();
            if (books.BookId > 0) {
                bookObj.BookId = books.BookId;
                if (bookObj.Load()) {
                    booksViewModelObj.BookId = bookObj.BookId;
                    booksViewModelObj.BookName = bookObj.BookName;
                    booksViewModelObj.BookCategoryId = bookObj.BookCategoryId;
                    booksViewModelObj.BookCategoryName = bookObj.BookCategoryName;
                    booksViewModelObj.BookPublisherId = bookObj.BookPublisherId;
                    booksViewModelObj.BookPublisherName = bookObj.BookPublisherName;
                    booksViewModelObj.BookQuantity = bookObj.BookQuantity;
                }
            }
            booksViewModelObj.BooksPublicationsList = new Books().BookPublicationsGetList();
            booksViewModelObj.BooksCategoriesList = new Books().BookCategoriesGetList();
            return View(booksViewModelObj);

        }

        [HttpPost]
        public ActionResult AddBook(BooksViewModel model) {
            Books books = new Books();
            books.BookId = model.BookId;
            books.BookName = model.BookName;
            books.BookCategoryId = model.BookCategoryId;
            books.BookPublisherId = model.BookPublisherId;
            books.BookQuantity = model.BookQuantity;
            books.IsActive = model.IsActive;
            books.Save();
            //return View(books);
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SearchBook(Books books) {

            BooksViewModel booksViewModelObj = new BooksViewModel();
            BooksViewModel bb = (BooksViewModel)Session["PrevData"];
            if (bb != null) {
                // booksViewModelObj = bb;
            }
            booksViewModelObj.BooksPublicationsList = new Books().BookPublicationsGetList();
            booksViewModelObj.BooksCategoriesList = new Books().BookCategoriesGetList();
            Session["PrevData"] = null;          
            return View(booksViewModelObj);
        }
        [HttpPost]
        public ActionResult SearchBook(BooksViewModel model) {

            Session["PrevData"] = null;

            Session["PrevData"] = model;

            Books bookObj = new Books();
            bookObj.BookName = model.BookName;
            bookObj.BookCategoryId = model.BookCategoryId;
            bookObj.BookPublisherId = model.BookPublisherId;
            bookObj.PageNumber = model.PageNumber;
            bookObj.PageSize = model.PageSize;
            model.BooksList = bookObj.GetList();
            model.TotalRecords = bookObj.TotalRecords;
            model.PageSize = bookObj.PageSize;

            return PartialView("_BookList", model);
        }


        public ActionResult EditBook(Books books) {

            Books bookObj = new Books();
            BooksViewModel booksViewModelObj = new BooksViewModel();
            if (books.BookId > 0) {
                bookObj.BookId = books.BookId;
                if (bookObj.Load()) {
                    booksViewModelObj.BookId = bookObj.BookId;
                    booksViewModelObj.BookName = bookObj.BookName;
                    booksViewModelObj.BookCategoryId = bookObj.BookCategoryId;
                    booksViewModelObj.BookCategoryName = bookObj.BookCategoryName;
                    booksViewModelObj.BookPublisherId = bookObj.BookPublisherId;
                    booksViewModelObj.BookPublisherName = bookObj.BookPublisherName;
                    booksViewModelObj.BookQuantity = bookObj.BookQuantity;
                    booksViewModelObj.IsActive = bookObj.IsActive;
                }
            }
            return Json(booksViewModelObj, JsonRequestBehavior.AllowGet);
        }
    }
}