--Create Database
CREATE DATABASE EcommDb;

USE EcommDb;

--Categories Table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

--Brands Table
CREATE TABLE Brands (
    BrandId INT PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL
);

--Products table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(100),
    BrandId INT,
    CategoryId INT,
    ModelYear INT,
    ListPrice DECIMAL(10,2)
);

--Customers table
CREATE TABLE customers (
    CustomerId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    City VARCHAR(50)
);

--Stores table
CREATE TABLE Stores (
    StoreId INT PRIMARY KEY,
    StoreName VARCHAR(100),
    Phone VARCHAR(20),
    City VARCHAR(50)
);

--Orders table

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    StoreId INT,
    ProductId INT,
    OrderDate DATE,
    Quantity INT,

    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);


--Insert at least 5 records

INSERT INTO Categories (CategoryId, CategoryName) VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'HomeAppliances'),
(4, 'Books'),
(5, 'Sports');

INSERT INTO Brands (BrandId, BrandName) VALUES
(1, 'Samsung'),
(2, 'Nike'),
(3, 'LG'),
(4, 'Sony'),
(5, 'Adidas');

INSERT INTO Products (ProductId, ProductName, BrandId, CategoryId, ModelYear, ListPrice) VALUES
(1, 'SamsungGalaxyS21', 1, 1, 2023, 65000),
(2, 'NikeRunningShoes', 2, 5, 2023, 5000),
(3, 'LGDoubleDoorFridge', 3, 3, 2022, 45000),
(4, 'SonyWirelessHeadphones', 4, 1, 2024, 8000),
(5, 'AdidasSportsTShirt', 5, 2, 2023, 2500);

INSERT INTO Customers (CustomerId, FirstName, LastName, Phone, Email, City) VALUES
(1, 'Ravi', 'Kumar', '9876543210', 'ravi@gmail.com', 'Hyderabad'),
(2, 'Anita', 'Sharma', '9876543211', 'anita@gmail.com', 'Delhi'),
(3, 'Rahul', 'Verma', '9876543212', 'rahul@gmail.com', 'Mumbai'),
(4, 'Priya', 'Reddy', '9876543213', 'priya@gmail.com', 'Chennai'),
(5, 'Arjun', 'Patel', '9876543214', 'arjun@gmail.com', 'Ahmedabad');

INSERT INTO Stores (StoreId, StoreName, Phone, City) VALUES
(1, 'TechStore', '9000000001', 'Hyderabad'),
(2, 'FashionHub', '9000000002', 'Delhi'),
(3, 'HomeMart', '9000000003', 'Bangalore'),
(4, 'BookWorld', '9000000004', 'Mumbai'),
(5, 'SportsArena', '9000000005', 'Pune');

INSERT INTO Orders (OrderId, CustomerId, StoreId, ProductId, OrderDate, Quantity)
VALUES
(1, 1, 1, 1, '2024-01-10', 1),
(2, 2, 2, 2, '2024-01-12', 2),
(3, 3, 3, 3, '2024-01-15', 1),
(4, 4, 1, 4, '2024-01-18', 1),
(5, 5, 5, 5, '2024-01-20', 3);

--Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb
--- Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.ProductName, b.BrandName, c.CategoryName 
FROM Products p 
INNER JOIN Brands b 
ON p.BrandId = b.BrandId
INNER JOIN Categories c 
ON p.CategoryId = c.CategoryId;

-- Retrieve all customers from a specific city.
SELECT * FROM customers WHERE City = 'Hyderabad';

-- Display total number of products available in each category.
SELECT c.CategoryName, COUNT(p.ProductId) AS TotalProducts
FROM Products p
INNER JOIN Categories c
ON p.CategoryId = c.CategoryId
GROUP BY c.CategoryName;

--Level-1 Problem 2: Creating Views and Indexes for Performance

--- Create a view that shows product name, brand name, category name, model year and list price.

CREATE VIEW vw_ProductDetails
AS SELECT p.ProductName, b.BrandName,
c.CategoryName, p.ModelYear, p.ListPrice 
FROM Products p 
INNER JOIN 
Brands b 
ON p.BrandId = b.BrandId 
INNER JOIN 
Categories c 
ON p.CategoryId = c.CategoryId;

--Read data
SELECT * FROM vw_ProductDetails;

-- Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_OrderDetails
AS
SELECT
    o.OrderId,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    s.StoreName
FROM Orders o
JOIN Customers c
    ON o.CustomerId = c.CustomerId
JOIN Stores s
    ON o.StoreId = s.StoreId;

SELECT * FROM vw_OrderDetails;


--- Create appropriate indexes on foreign key columns.
CREATE INDEX IdxProductsBrandId
ON Products(BrandId);

CREATE INDEX IdxProductsCategoryId
ON Products(CategoryId);

CREATE INDEX IdxOrdersCustomerId
ON Orders(CustomerId);

CREATE INDEX IdxOrdersStoreId
ON Orders(StoreId);

CREATE INDEX IdxOrdersProductId
ON Orders(ProductId);

--Test performance improvement using execution plan.

SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT p.ProductName, b.BrandName
FROM Products p
JOIN Brands b
ON p.BrandId = b.BrandId;