USE Fake_Library
GO

CREATE PROCEDURE dbo.uspCopiesbyTitle_Branch @Title NVARCHAR(50), @Branch NVARCHAR(50) 
AS
	SELECT Book_Copies.No_Of_Copies FROM Book_Copies
		INNER JOIN Book ON Book.BookId = Book_Copies.BookId
		INNER JOIN Library_Branch ON Library_Branch.BranchId = Book_Copies.BranchId
	WHERE @Title = Book.Title AND @Branch =  Library_Branch.BranchName
GO

EXECUTE dbo.uspCopiesbyTitle_Branch 'The Lost Tribe', 'Sharpstown'
GO

CREATE PROCEDURE dbo.uspCopiesperBranch_Title @Title NVARCHAR(50)
AS
	SELECT Library_Branch.BranchName, Book_Copies.No_Of_Copies FROM Book_Copies
		INNER JOIN Book ON Book.BookId = Book_Copies.BookId
		INNER JOIN Library_Branch ON Library_Branch.BranchId = Book_Copies.BranchId
	WHERE @Title = Book.Title 
	ORDER BY Library_Branch.BranchName ASC
GO

EXECUTE dbo.uspCopiesperBranch_Title 'The Lost Tribe'
GO

CREATE PROCEDURE dbo.uspNoBooks
AS
	SELECT a.Name FROM Borrower a
		LEFT JOIN Book_Loans b ON a.CardNo = b.CardNo
	GROUP BY a.Name
	HAVING COUNT (b.CardNo) = 0
GO

EXECUTE dbo.uspNoBooks
GO

CREATE PROCEDURE dbo.uspBooksDue
AS 
	DECLARE @today DATE = GETDATE()
	SELECT B.Title, C.Name, C.Address FROM Book_Loans A
	INNER JOIN Book B ON A.BookId = B.BookId 
	INNER JOIN Borrower C ON A.CardNo = C.CardNo
	WHERE @today = A.DateDue
GO

EXECUTE dbo.uspBooksDue
GO

CREATE PROCEDURE dbo.uspBooksDue_Branch @Branch NVARCHAR(50)
AS 
	DECLARE @today DATE = GETDATE()
	IF EXISTS 
		(SELECT * FROM Book_Loans A
		INNER JOIN Book B ON A.BookId = B.BookId 
		INNER JOIN Borrower C ON A.CardNo = C.CardNo
		INNER JOIN Library_Branch L ON A.BranchId = L.BranchId 
		WHERE @today = A.DateDue AND @Branch = L.BranchName)
	BEGIN
		SELECT B.Title, C.Name, C.Address FROM Book_Loans A
		INNER JOIN Book B ON A.BookId = B.BookId 
		INNER JOIN Borrower C ON A.CardNo = C.CardNo
		INNER JOIN Library_Branch L ON A.BranchId = L.BranchId 
		WHERE @today = A.DateDue AND @Branch = L.BranchName
	END
	ELSE
	BEGIN
		PRINT 'No Books Due at the ' + @Branch + ' location today.'
	END
GO

EXECUTE dbo.uspBooksDue_Branch 'Sharpstown'
GO

EXECUTE dbo.uspBooksDue_Branch 'Central'
GO

CREATE PROCEDURE dbo.uspBooksOut
AS
	SELECT A.BranchName, COUNT(B.BranchId) FROM Library_Branch A
		INNER JOIN Book_Loans B ON A.BranchId = B.BranchId
	GROUP BY A.BranchName
GO

EXECUTE dbo.uspBooksOut
GO

CREATE PROCEDURE dbo.uspBooksOut_BigBorrower
AS 
	SELECT B.Name, B.Address, COUNT(A.CardNo) FROM Book_Loans A
		INNER JOIN Borrower B On A.CardNo = B.CardNo
	GROUP BY B.Name, B.Address
	HAVING COUNT(A.CardNo) > 5
GO 

EXECUTE dbo.uspBooksOut_BigBorrower
GO

CREATE PROCEDURE dbo.uspTitlebyAuthor_Branch @author NVARCHAR(50), @branch NVARCHAR(50)
AS
	SELECT A.Title, B.No_Of_Copies FROM Book A
	INNER JOIN Book_Copies B ON A.BookId = B.BookId
	INNER JOIN Book_Author C ON A.BookId = C.BookId
	INNER JOIN Library_Branch L ON  B.BranchID = L.BranchId
	WHERE @author = C.AuthorName AND @branch = L.BranchName
GO

EXECUTE dbo.uspTitlebyAuthor_Branch 'Stephen King', 'Central'
GO