--Assignment Case Study: Stored Procedures & Transactions in SQL Server 

 --Business Scenario – “BookMart Online Bookstore” (Simplified)

 --Create the Database
 CREATE DATABASE BookMartDB;

 USE BookMartDB;

CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

--Sample data
INSERT INTO Books (Title, Stock, Price) VALUES
('Clean Code', 10, 45.99),
('The Pragmatic Programmer', 5, 50.00),
('SQL Server Fundamentals', 3, 35.50),
('Design Patterns', 8, 60.00),
('Database System Concepts', 6, 55.25);


INSERT INTO Orders (BookID, Quantity) VALUES
(1, 2),
(2, 1),
(3, 1),
(1, 3),
(4, 2);

--Task 1: Stored Procedure to Add a Book  

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);
        PRINT 'Book added successfully.';
    END TRY

    BEGIN CATCH
        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + 
              ': ' + ERROR_MESSAGE();
    END CATCH
END;



--Task 2 – Main Procedure: Place Order with Transaction

CREATE PROCEDURE sp_PlaceOrder
 @BookId INT,
 @Quantity INT
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

		IF NOT EXISTS (
		   SELECT 1 
		   FROM Books
		   WHERE BookId = @BookId
		   AND Stock >= @Quantity
		)

		BEGIN
		  RAISERROR('Not enough stock or book not found.', 16, 1);
		END 

		Update Books 
		SET Stock = Stock - @Quantity
		WHERE BookId = @BookId


		INSERT INTO Orders (BookId, Quantity)
		VALUES (@BookId, @Quantity);

		COMMIT TRANSACTION;

		PRINT 'Order placed successfully.';

	END TRY 

	BEGIN CATCH 

	 IF @@TRANCOUNT > 0 
	   ROLLBACK TRANSACTION;
	   
        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) +
              ': ' + ERROR_MESSAGE();

    END CATCH

END;

--

--Add new books
EXEC sp_AddNewBook 'Atomic Habits', 10, 45.99;
EXEC sp_AddNewBook 'Wise and Otherwise', 5, 50.00;


-- Successful order
EXEC sp_PlaceOrder 1, 2;

-- Insufficient stock
EXEC sp_PlaceOrder 3, 10;