using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DemoWebApplication.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;

public class Books {
    #region Basic Functionality

    #region Variable Declaration
    private Database db;
    #endregion

    #region Constructors

    public Books() {
        this.db = DatabaseFactory.CreateDatabase();
    }

    public Books(int BookId) {
        this.db = DatabaseFactory.CreateDatabase();
        this.BookId = BookId;
    }
    #endregion

    #region Properties

    public int BookId { get; set; }
    public string BookName { get; set; }
    public int BookCategoryId { get; set; }
    public int BookPublisherId { get; set; }
    public String BookCategoryName { get; set; }
    public String BookPublisherName { get; set; }
    public int BookQuantity { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int TotalRecords { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; }
    #endregion

    #region Actions

    public bool Save() {
        if (this.BookId == 0) {
            return this.Insert();
        } else {
            if (this.BookId > 0) {
                return this.Update();
            } else {
                this.BookId = 0;
                return false;
            }
        }
    }
    private bool Insert() {
        try {
            DbCommand com = this.db.GetStoredProcCommand("BooksInsert");

            this.db.AddOutParameter(com, "BookId", DbType.Int32, 1024);

            if (!String.IsNullOrEmpty(this.BookName)) {
                this.db.AddInParameter(com, "BookName", DbType.String, this.BookName);
            } else {
                this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
            }

            if (this.BookCategoryId > 0) {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, this.BookCategoryId);
            } else {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, DBNull.Value);
            }

            if (this.BookPublisherId > 0) {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, this.BookPublisherId);
            } else {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, DBNull.Value);
            }

            if (this.BookQuantity > 0) {
                this.db.AddInParameter(com, "BookQuantity", DbType.Int32, this.BookQuantity);
            } else {
                this.db.AddInParameter(com, "BookQuantity", DbType.Int32, DBNull.Value);
            }

            this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);

            if (this.CreatedBy > 0) {
                this.db.AddInParameter(com, "CreatedBy", DbType.Int32, 1);
            } else {
                this.db.AddInParameter(com, "CreatedBy", DbType.Int32, 1);
            }

            if (this.CreatedOn > DateTime.MinValue) {
                this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DateTime.Now);
            } else {
                this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DateTime.Now);
            }

            if (this.ModifiedBy > 0) {
                this.db.AddInParameter(com, "ModifiedBy", DbType.Int32,1);
            } else {
                this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, 1);
            }
            if (this.ModifiedOn > DateTime.MinValue) {
                this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DateTime.Now);
            } else {
                this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DateTime.Now);
            }

            this.db.ExecuteNonQuery(com);

            this.BookId = Convert.ToInt32(this.db.GetParameterValue(com, "BookId"));      // Read in the output parameter value

        } catch (Exception ex) {
            // To Do: Handle Exception
            return false;
        }

        return this.BookId > 0; // Return whether ID was returned
    }
    private bool Update() {
        try {
            DbCommand com = this.db.GetStoredProcCommand("BooksUpdate");

            this.db.AddInParameter(com, "BookId", DbType.Int32, this.BookId);

            if (!String.IsNullOrEmpty(this.BookName)) {
                this.db.AddInParameter(com, "BookName", DbType.String, this.BookName);
            } else {
                this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
            }
            if (this.BookCategoryId > 0) {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, this.BookCategoryId);
            } else {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, DBNull.Value);
            }

            if (this.BookPublisherId > 0) {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, this.BookPublisherId);
            } else {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, DBNull.Value);
            }

            if (this.BookQuantity > 0) {
                this.db.AddInParameter(com, "BookQuantity", DbType.Int32, this.BookQuantity);
            } else {
                this.db.AddInParameter(com, "BookQuantity", DbType.Int32, DBNull.Value);
            }
            this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);

            if (this.CreatedBy > 0) {
                this.db.AddInParameter(com, "CreatedBy", DbType.Int32, this.CreatedBy);
            } else {
                this.db.AddInParameter(com, "CreatedBy", DbType.Int32, DBNull.Value);
            }

            if (this.CreatedOn > DateTime.MinValue) {
                this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, this.CreatedOn);
            } else {
                this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DBNull.Value);
            }

            if (this.ModifiedBy > 0) {
                this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, this.ModifiedBy);
            } else {
                this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, DBNull.Value);
            }

            if (this.ModifiedOn > DateTime.MinValue) {
                this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, this.ModifiedOn);
            } else {
                this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DBNull.Value);
            } 

            this.db.ExecuteNonQuery(com);

           

        } catch (Exception ex) {
            // To Do: Handle Exception
            return false;
        }

        return true;
    }
    public bool Delete() {
        try {
            DbCommand com = this.db.GetStoredProcCommand("BooksDelete");
            this.db.AddInParameter(com, "BookId", DbType.Int32, this.BookId);
            this.db.ExecuteNonQuery(com);
        } catch (Exception ex) {
            // To Do: Handle Exception
            return false;
        }
        return true;
    }
    public List<BooksViewModel> GetList() {
        DataSet dsBooksList = null;
        List<BooksViewModel> BooksList = null;
        try {
            DbCommand com = db.GetStoredProcCommand("BooksGetList");

            if (!String.IsNullOrEmpty(this.BookName)) {
                this.db.AddInParameter(com, "BookName", DbType.String, this.BookName);
            } else {
                this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
            }

            if (this.BookCategoryId > 0) {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, this.BookCategoryId);
            } else {
                this.db.AddInParameter(com, "BookCategoryId", DbType.Int32, DBNull.Value);
            }

            if (this.BookPublisherId > 0) {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, this.BookPublisherId);
            } else {
                this.db.AddInParameter(com, "BookPublisherId", DbType.Int32, DBNull.Value);
            }

            if (this.PageNumber > 0) {
                this.db.AddInParameter(com, "PageNumber", DbType.Int32, this.PageNumber);
            } else {
                this.db.AddInParameter(com, "PageNumber", DbType.Int32, 1);
            }

            if (this.PageSize > 0) {
                this.db.AddInParameter(com, "PageSize", DbType.Int32, this.PageSize);
            } else {
                this.db.AddInParameter(com, "PageSize", DbType.Int32, 10);
            }

            this.db.AddOutParameter(com, "TotalRecords", DbType.Int32, 1024);

            dsBooksList = db.ExecuteDataSet(com);

            this.TotalRecords = Convert.ToInt32(this.db.GetParameterValue(com, "TotalRecords"));
         
            BooksList = new List<BooksViewModel>();

            for (int i = 0; i < dsBooksList.Tables[0].Rows.Count; i++) {
                BooksList.Add(new BooksViewModel() {
                    BookId = Convert.ToInt32(dsBooksList.Tables[0].Rows[i]["BookId"]),
                    BookName = dsBooksList.Tables[0].Rows[i]["BookName"].ToString(),
                    BookCategoryName = dsBooksList.Tables[0].Rows[i]["BookCategoryName"].ToString(),
                    BookPublisherName = dsBooksList.Tables[0].Rows[i]["BookPublisherName"].ToString(),
                    BookQuantity = Convert.ToInt32(dsBooksList.Tables[0].Rows[i]["BookQuantity"])
                });
            }
        } catch (Exception ex) {
            Console.WriteLine(ex);
            //To Do: Handle Exception
        }
        return BooksList;
    }
    public bool Load() {
        try {
            if (this.BookId != 0) {
                DbCommand com = this.db.GetStoredProcCommand("BooksGetDetails");
                this.db.AddInParameter(com, "BookId", DbType.Int32, this.BookId);
                DataSet ds = this.db.ExecuteDataSet(com);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                    DataTable dt = ds.Tables[0];
                    this.BookId = Convert.ToInt32(dt.Rows[0]["BookId"]);
                    this.BookName = Convert.ToString(dt.Rows[0]["BookName"]);
                    this.BookCategoryId = Convert.ToInt32(dt.Rows[0]["BookCategoryId"]);
                    this.BookCategoryName = Convert.ToString(dt.Rows[0]["BookCategoryName"]);
                    this.BookPublisherId = Convert.ToInt32(dt.Rows[0]["BookPublisherId"]);
                    this.BookPublisherName = Convert.ToString(dt.Rows[0]["BookPublisherName"]);
                    this.BookQuantity = Convert.ToInt32(dt.Rows[0]["BookQuantity"]);
                    this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    this.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    this.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    this.ModifiedBy = Convert.ToInt32(dt.Rows[0]["ModifiedBy"]);
                    this.ModifiedOn = Convert.ToDateTime(dt.Rows[0]["ModifiedOn"]);
                    return true;
                }
            }
            return false;
        } catch (Exception ex) {
            // To Do: Handle Exception
            return false;
        }
    }
    public List<BooksViewModel> BookCategoriesGetList() {
        DataSet dsBookCategoriesGetList = null;
        List<BooksViewModel> BookCategoriesGetList = null;
        try {
            DbCommand com = db.GetStoredProcCommand("BookCategoriesGetList");
            dsBookCategoriesGetList = db.ExecuteDataSet(com);
            BookCategoriesGetList = new List<BooksViewModel>();

            for (int i = 0; i < dsBookCategoriesGetList.Tables[0].Rows.Count; i++) {

                BookCategoriesGetList.Add(new BooksViewModel() {
                    BookCategoryId = Convert.ToInt32(dsBookCategoriesGetList.Tables[0].Rows[i]["BookCategoryId"]),
                    BookCategoryName = dsBookCategoriesGetList.Tables[0].Rows[i]["BookCategoryName"].ToString()
                });
            }
        } catch (Exception ex) {
            Console.WriteLine(ex);
            //To Do: Handle Exception
        }
        return BookCategoriesGetList;
    }
    public List<BooksViewModel> BookPublicationsGetList() {
        DataSet dsBookPublicationsGetList = null;
        List<BooksViewModel> BookPublicationsGetList = null;
        try {
            DbCommand com = db.GetStoredProcCommand("BookPublicationsGetList");
            dsBookPublicationsGetList = db.ExecuteDataSet(com);
            BookPublicationsGetList = new List<BooksViewModel>();

            for (int i = 0; i < dsBookPublicationsGetList.Tables[0].Rows.Count; i++) {
                BookPublicationsGetList.Add(new BooksViewModel() {
                    BookPublisherId = Convert.ToInt32(dsBookPublicationsGetList.Tables[0].Rows[i]["BookPublisherId"]),
                    BookPublisherName = dsBookPublicationsGetList.Tables[0].Rows[i]["BookPublisherName"].ToString()
                });

            }
        } catch (Exception ex) {
            Console.WriteLine(ex);
            //To Do: Handle Exception
        }
        return BookPublicationsGetList;
    }
    #endregion
    #endregion
}
