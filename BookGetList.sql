USE [LibraryManagement]
GO
/****** Object:  StoredProcedure [dbo].[BooksGetList]    Script Date: 08-06-2022 17:17:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BooksGetList]
	@BookName VARCHAR(50) = null, @BookPublisherId INT = null, @BookCategoryId INT = null
	AS BEGIN

	SELECT 
		[Books].[BookId],							[Books].[BookName],
		[BookCategories].[BookCategoryId],			[BookCategories].[BookCategoryName],
		[BookPublishers].[BookPublisherId],			[BookPublishers].[BookPublisherName],	
		[BookQuantity],								[Books].[IsActive],
		[Books].[CreatedBy],						[Books].[CreatedOn],		
		[Books].[ModifiedBy],
		[Books].[ModifiedOn]						
	FROM
		[Books] Inner Join BookCategories On [BookCategories].BookCategoryId = [Books].BookCategoryId
				Inner Join BookPublishers On [BookPublishers].BookPublisherId = [Books].BookPublisherId
	Where
		 ([Books].[BookName] LIKE '%'+@BookName+'%' OR @BookName IS NULL)
		 AND  ([BookCategories].BookCategoryId = @BookCategoryId OR @BookCategoryId IS NULL) 	
		 AND  ([BookPublishers].BookPublisherId  = @BookPublisherId OR @BookPublisherId IS NULL) 
		 AND  Books.IsActive = 1 
	ORDER BY 
		 BookId 
	
END
