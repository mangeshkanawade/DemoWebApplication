USE [TRAINING]
GO
/****** Object:  StoredProcedure [dbo].[BooksGetList]    Script Date: 08-06-2022 17:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[BooksGetList]
	@BookName VARCHAR(50) = null, @BookPublisherId INT = null, @BookCategoryId INT = null, @PageNumber INT = 1, @PageSize INT = 10
	AS BEGIN

	DECLARE @TotalRecords INT = 0

	SELECT 
		[Books].[BookId],
		[Books].[BookName],
		[BookCategories].[BookCategoryId],
		[BookCategories].[BookCategoryName],
		[BookPublishers].[BookPublisherId],	
		[BookPublishers].[BookPublisherName],	
		[BookQuantity],
		[Books].[IsActive],
		[Books].[CreatedBy],
		[Books].[CreatedOn],
		[Books].[ModifiedBy],
		[Books].[ModifiedOn], ROW_NUMBER() OVER (ORDER BY BookId) as RowNumber	into #TempBooks
	FROM
		[Books] Inner Join BookCategories On [BookCategories].BookCategoryId = [Books].BookCategoryId
				Inner Join BookPublishers On [BookPublishers].BookPublisherId = [Books].BookPublisherId
	Where
		 ([Books].[BookName] LIKE '%'+@BookName+'%' OR @BookName IS NULL)
	AND  ([BookCategories].BookCategoryId = @BookCategoryId OR @BookCategoryId IS NULL) 	
	AND  ([BookPublishers].BookPublisherId  = @BookPublisherId OR @BookPublisherId IS NULL)
	
	ORDER BY BookId 

	SELECT @TotalRecords = COUNT(BookId) from #TempBooks
	
	
	SELECT*,  @TotalRecords AS TotalRecords FROM #TempBooks
	where RowNumber between (@PageNumber - 1) * @PageSize + 1 and @PageNumber * @PageSize

	drop table #TempBooks
END
