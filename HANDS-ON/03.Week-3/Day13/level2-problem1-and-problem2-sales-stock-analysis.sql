--Create Database
CREATE DATABASE SalesDB;

-- Create tables
--1.Stores table
CREATE TABLE Stores (
    StoreId INT IDENTITY(1,1) PRIMARY KEY,
    StoreName VARCHAR(100) NOT NULL
);

--inserting sample data
INSERT INTO Stores (StoreName)
VALUES
('Central Store'),
('North Branch'),
('South Branch');

SELECT * FROM Stores;

--2.Orders table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    StoreId INT NOT NULL,
    OrderStatus INT NOT NULL,
    OrderDate DATE,
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

--inserting sample data
INSERT INTO Orders (StoreId, OrderStatus, OrderDate)
VALUES
(1, 4, '2026-03-01'),
(2, 4, '2026-03-02'),
(3, 2, '2026-03-03'),
(1, 4, '2026-03-04');



--3.Products table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    ListPrice DECIMAL(10,2) NOT NULL
);

--inserting sample data
INSERT INTO Products (ProductName, ListPrice)
VALUES
('Laptop', 1200),
('Smartphone', 800),
('Headphones', 200),
('Tablet', 600);

--4.OrderItems table
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL,
    Discount DECIMAL(4,2) DEFAULT 0,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

--inserting sample data
INSERT INTO OrderItems (OrderId, ProductId, Quantity, ListPrice, Discount)
VALUES
(1, 1, 2, 1200, 0.10),
(1, 3, 3, 200, 0.05),
(2, 2, 1, 800, 0.00),
(2, 4, 2, 600, 0.15),
(3, 3, 4, 200, 0.05),
(4, 1, 1, 1200, 0.10);

--create stocks table
CREATE TABLE Stocks (
    StoreId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    PRIMARY KEY (StoreId, ProductId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

--inserting sample data
INSERT INTO Stocks (StoreId, ProductId, Quantity)
VALUES
(1, 1, 50),
(1, 2, 30),
(1, 3, 20),
(2, 1, 40),
(2, 3, 25),
(2, 4, 15),
(3, 2, 35),
(3, 4, 10);

--1. Display store_name and total sales amount.
 --2.Calculate total sales using (quantity * list_price * (1 - discount)).
 --3. Include only completed orders (order_status = 4).
--4. Group results by store_name.
--5. Sort total sales in descending order.

SELECT 
    s.StoreName,
    SUM(oi.Quantity * oi.ListPrice * (1 - oi.Discount)) AS TotalSales
FROM Stores s
INNER JOIN Orders o 
    ON s.StoreId = o.StoreId
INNER JOIN OrderItems oi 
    ON o.OrderId = oi.OrderId
WHERE o.OrderStatus = 4
GROUP BY s.StoreName
ORDER BY TotalSales DESC;

--4 - Product Stock and Sales Analysis

--1. Display product_name, store_name, available stock quantity, and total quantity sold.
--2. Include products even if they have not been sold (use appropriate join).
--3. Group results by product_name and store_name.
--4. Sort results by product_name.

SELECT 
    p.ProductName,
    s.StoreName,
    st.Quantity AS StockQuantity,
    ISNULL(SUM(oi.Quantity), 0) AS TotalQuantitySold
FROM Stocks st
INNER JOIN Products p
    ON st.ProductId = p.ProductId
INNER JOIN Stores s
    ON st.StoreId = s.StoreId
LEFT JOIN Orders o
    ON s.StoreId = o.StoreId
LEFT JOIN OrderItems oi
    ON o.OrderId = oi.OrderId
    AND st.ProductId = oi.ProductId
GROUP BY 
    p.ProductName,
    s.StoreName,
    st.Quantity
ORDER BY 
    p.ProductName;

   
