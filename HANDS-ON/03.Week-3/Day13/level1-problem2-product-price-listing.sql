--Create Database
CREATE DATABASE StoreDB;

--Create Tables
--1.Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    BrandId INT NOT NULL,
    CategoryId INT NOT NULL,
    ModelYear INT NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (BrandId) REFERENCES Brands(BrandId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- Storing sample data
INSERT INTO Products (ProductName, BrandId, CategoryId, ModelYear, ListPrice)
VALUES
('Air Max Shoes', 1, 1, 2023, 650),
('Running Pro Shoes', 2, 1, 2022, 480),
('Galaxy S23', 3, 3, 2023, 950),
('iPhone 14', 4, 3, 2023, 1200),
('Sony Headphones', 5, 5, 2022, 550),
('MacBook Air', 4, 4, 2023, 1500),
('Samsung Laptop', 3, 4, 2022, 700);


--2.Brands
CREATE TABLE Brands (
    BrandId INT IDENTITY(1,1) PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL
);

-- Storing sample data
INSERT INTO Brands (BrandName)
VALUES
('Nike'),
('Adidas'),
('Samsung'),
('Apple'),
('Sony');

--3 Categories
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

--Storing sample data
INSERT INTO Categories (CategoryName)
VALUES
('Shoes'),
('Electronics'),
('Smartphones'),
('Laptops'),
('Accessories');

--1. Display product_name, brand_name, category_name, model_year, and list_price.
--2. Filter products with list_price greater than 500.
--3. Sort results by list_price in ascending order.

SELECT 
    p.ProductName,
    b.BrandName,
    c.CategoryName,
    p.ModelYear,
    p.ListPrice
FROM Products p
INNER JOIN Brands b
    ON p.BrandId = b.BrandId
INNER JOIN Categories c
    ON p.CategoryId = c.CategoryId
WHERE p.ListPrice > 500
ORDER BY p.ListPrice ASC;

