--Create Database
CREATE DATABASE RetailDB;

USE RetailDB;

--Create Tables
--1.Stores Table
CREATE TABLE Stores (
    StoreId INT PRIMARY KEY IDENTITY(1,1),
    StoreName VARCHAR(100) NOT NULL,
    City VARCHAR(100)
);

--Sample data
INSERT INTO stores (StoreName, City) VALUES
('Hyderabad Central Store', 'Hyderabad'),
('Bangalore Mega Store', 'Bangalore'),
('Chennai Super Store', 'Chennai');

--Products Table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(150) NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL
);

--Sample Data
INSERT INTO Products (ProductName, ListPrice) VALUES
('Laptop', 70000),
('Mobile Phone', 25000),
('Tablet', 18000),
('Smart Watch', 12000),
('Headphones', 3000),
('Bluetooth Speaker', 4500);

--Stocks Table
CREATE TABLE Stocks (
    StockId INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT,
    StoreId INT,
    Quantity INT,

    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

--Sample Data
INSERT INTO Stocks (ProductId, StoreId, Quantity) VALUES
(1,1,50),
(2,1,80),
(3,1,60),
(4,1,40),
(5,1,100),
(1,2,30),
(2,2,70),
(3,2,50),
(4,3,25),
(5,3,90);

--Customers Table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100),
    City VARCHAR(100)
);

--Sample Data
INSERT INTO Customers (CustomerName, City) VALUES
('Rahul Sharma', 'Hyderabad'),
('Anita Verma', 'Bangalore'),
('Karthik R', 'Chennai'),
('Priya Singh', 'Delhi');


--Orders Table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT,
    StoreId INT,
    OrderDate DATE,
    ShippedDate DATE NULL,
    OrderStatus INT,

    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

--Sample Data
INSERT INTO Orders (CustomerId, StoreId, OrderDate, ShippedDate, OrderStatus) VALUES
(1,1,'2025-02-01','2025-02-03',4),
(2,2,'2025-02-05','2025-02-07',4),
(3,1,'2025-02-08',NULL,1),
(4,3,'2025-02-10','2025-02-12',4);

--OrderItems Table
CREATE TABLE OrderItems (
    ItemId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    ProductId INT,
    Quantity INT,
    ListPrice DECIMAL(10,2),
    Discount DECIMAL(5,2) DEFAULT 0,

    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

--Sample Data
INSERT INTO OrderItems (OrderId, ProductId, Quantity, ListPrice, Discount) VALUES
(1,1,2,70000,10),
(1,5,3,3000,5),
(2,2,1,25000,8),
(2,4,2,12000,5),
(3,3,1,18000,0),
(4,1,1,70000,15),
(4,5,2,3000,10);


--Level-2 Problem 1: Stored Procedures and User-Defined Functions

-- Create a stored procedure to generate total sales amount per store.

CREATE PROCEDURE usp_GenerateTotalSalesPerStore
AS
BEGIN 
   SELECT 
     s.StoreName,
     SUM(oi.Quantity * oi.ListPrice) AS TotalSales
   FROM Stores s 
   JOIN Orders o 
     ON s.StoreId = o.StoreId
   JOIN OrderItems oi 
     ON o.OrderId = oi.OrderId
   GROUP BY s.StoreName

END

--Execute Procedure
EXEC usp_GenerateTotalSalesPerStore

-- Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE usp_GetOrdersByDateRange
   @StartDate DATE,
   @EndDate DATE
AS
BEGIN
  SELECT 
      OrderId,
      CustomerId,
      StoreId,
      OrderDate,
      ShippedDate,
      OrderStatus
    FROM Orders
  WHERE OrderDate BETWEEN @StartDate AND @EndDate

  END
     
--Excecute Procedure
EXEC usp_GetOrdersByDateRange
@StartDate = '2025-01-01',
@EndDate = '2025-12-31'

-- Create a scalar function to calculate total price after discount.
CREATE FUNCTION dbo.udf_CalculateTotalPriceAfterDiscount
(
@Price DECIMAL(10,2),
@Quantity INT,
@Discount DECIMAL(5,2)
) 
RETURNS DECIMAL(10,2)
AS
BEGIN 
 RETURN((@Price * @Quantity) - (@Price * @Quantity)*@Discount/100);
END;

--Invoke Function
SELECT dbo.udf_CalculateTotalPriceAfterDiscount(1000.0,2,10) AS FinalPrice


-- Create a table-valued function to return top 5 selling products.
CREATE FUNCTION dbo.usd_GetTopSellingProducts()
RETURNS TABLE 
AS  
RETURN
  (SELECT TOP 5 ProductId,
   SUM(Quantity) AS TotalSold
   FROM OrderItems 
   GROUP BY ProductId
   ORDER BY TotalSold DESC
)

--Invoke Function 
SELECT * FROM dbo.usd_GetTopSellingProducts();

