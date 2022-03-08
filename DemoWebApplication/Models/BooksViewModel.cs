using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApplication.Models {
    public class BooksViewModel {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookCategoryId { get; set; }
        public int BookPublisherId { get; set; }
        public int BookQuantity { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String BookCategoryName { get; set; }
        public String BookPublisherName { get; set; }
        public List<BooksViewModel> BooksPublicationsList { get; set; }
        public List<BooksViewModel> BooksCategoriesList { get; set; }
        public List<BooksViewModel> BooksList { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}