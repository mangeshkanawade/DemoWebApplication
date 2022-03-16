using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApplication.Models {
    public class BooksViewModel {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please Enter Book Name First")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please Select Book Category First")]
        public int BookCategoryId { get; set; }

        [Required(ErrorMessage = "Please Select Book Publication First")]
        public int BookPublisherId { get; set; }

        [Required(ErrorMessage = "Please Enter Book Quantity First")]
        [Range(1, 100, ErrorMessage = "Quantity Must be More than 1")]
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
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }
}