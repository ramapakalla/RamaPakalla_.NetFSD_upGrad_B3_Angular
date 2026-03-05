--Create Database
CREATE DATABASE AutoDb;

USE AutoDb;

--Create Tables
CREATE TABLE Categories
(
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(150) NOT NULL,
    CategoryId INT NOT NULL,
    ModelYear INT NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Products_Categories
    FOREIGN KEY (CategoryId)
    REFERENCES Categories(CategoryId)
);

--Insert Sample Data
INSERT INTO Categories (CategoryName)
VALUES
('Mountain Bikes'),
('Road Bikes'),
('Electric Bikes'),
('Kids Bikes');

INSERT INTO Products (ProductName, CategoryId, ModelYear, ListPrice)
VALUES
('Trek Marlin 5', 1, 2018, 489.99),
('Giant Talon 3', 1, 2019, 520.00),
('Specialized Rockhopper', 1, 2017, 650.00),
('Trek Domane AL 2', 2, 2018, 850.00),
('Giant Contend 3', 2, 2019, 780.00),
('Cannondale CAAD Optimo', 2, 2017, 900.00),
('Rad Power RadCity', 3, 2020, 1500.00),
('Trek Allant+ 7', 3, 2021, 3200.00),
('Specialized Turbo Vado', 3, 2022, 3500.00),

('Trek Precaliber 20', 4, 2018, 289.99),
('Co-op Cycles REV 16', 4, 2019, 250.00),
('Guardian Ethos 20', 4, 2020, 320.00);

SELECT * FROM Categories;
SELECT * FROM Products;

--Level-1: Problem 1 – Product Analysis Using Nested Queries
--📌 Requirements
--1. Retrieve product details (product_name, model_year, list_price).
--2. Compare each product’s price with the average price of products in the same category using a nested query.
--3. Display only those products whose price is greater than the category average.
--4. Show calculated difference between product price and category average.
--5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

SELECT 
   CONCAT(p.ProductName,' (', p.ModelYear,')') AS ProductInfo, p.ProductName, p.ModelYear, p.ListPrice, 
   --Avg price of products in same category
 (SELECT AVG(p2.ListPrice) 
   FROM Products p2
   WHERE p.CategoryId = p2.CategoryId)
   AS CategoryAveragePrice,
   --difference between product price and category average
   p.ListPrice - 
   (SELECT AVG(p3.ListPrice)
     FROM Products p3 
	 WHERE p.CategoryId = p3.CategoryId) AS PriceDifference

FROM Products p WHERE p.ListPrice >
     --products whose price is greater than the category average
  (SELECT AVG(p4.ListPrice)
   FROM Products p4 
   WHERE p.CategoryId = p4.CategoryId) 

--Level-1: Problem 2 – Customer Activity Classification
--📌 Requirements
--1. Use nested query to calculate total order value per customer.
--2. Classify customers using conditional logic:
  -- - 'Premium' if total order value > 10000
  -- - 'Regular' if total order value between 5000 and 10000
  -- - 'Basic' if total order value < 5000
--3. Use UNION to display customers with orders and customers without orders.
--4. Display full name using string concatenation.
--5. Handle NULL cases appropriately.


--Customers table
CREATE TABLE Customers
(
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100)
);

--Orders table
CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT,
    OrderDate DATE,
    OrderAmount DECIMAL(10,2),

    FOREIGN KEY (CustomerId)
    REFERENCES Customers(CustomerId)
);

--Insert Sample Data
INSERT INTO Customers (FirstName, LastName, Email)
VALUES
('Ravi','Kumar','ravi@email.com'),
('Sneha','Reddy','sneha@email.com'),
('Arjun','Sharma','arjun@email.com'),
('Meena','Patel','meena@email.com'),
('Kiran','Verma','kiran@email.com'),
('Anita','Joshi','anita@email.com');


INSERT INTO Orders (CustomerId, OrderDate, OrderAmount)
VALUES
(1,'2024-01-10',3000),
(1,'2024-02-15',2500),
(1,'2024-03-20',2000),

(2,'2024-01-12',6000),
(2,'2024-03-10',5500),

(3,'2024-02-05',2000),
(3,'2024-04-01',1500),

(4,'2024-03-25',12000);

   SELECT 
  CONCAT(c.FirstName,' ', c.LastName) AS CustomerName,
  (SELECT SUM(o.OrderAmount)
   FROM Orders o
   WHERE o.CustomerId = c.CustomerId) AS TotalOrderValue,  -- calculating total order value
   --conditions
  CASE 
      WHEN SUM(o.OrderAmount) > 10000 
           THEN 'Premium'

      WHEN SUM(o.OrderAmount) BETWEEN 5000 AND 10000
           THEN 'Regular'

      WHEN SUM(o.OrderAmount) < 5000 
           THEN 'Basic'
  END AS CustomerCategory

FROM Customers c
JOIN Orders o
ON c.CustomerId = o.CustomerId

GROUP BY c.CustomerId, c.FirstName, c.LastName

UNION

SELECT 
  CONCAT(c.FirstName,' ', c.LastName) AS CustomerName,
  NULL AS TotalOrderValue,
  'No Orders' AS CustomerCategory
FROM Customers c
WHERE c.CustomerId NOT IN
(
   SELECT CustomerId FROM Orders
);


--Level-2: Problem 3 – Store Performance and Stock Validation


--Stores Table 
CREATE TABLE Stores
(
    StoreId INT PRIMARY KEY IDENTITY(1,1),
    StoreName NVARCHAR(100) NOT NULL
);

--Insert sample data
INSERT INTO Stores (StoreName)
VALUES
('Hyderabad Store'),
('Mumbai Store'),
('Delhi Store');


--Stocks table
CREATE TABLE Stocks
(
    StoreId INT,
    ProductId INT,
    Quantity INT,

    CONSTRAINT PK_Stocks PRIMARY KEY (StoreId, ProductId),

    CONSTRAINT FK_Stocks_Stores
    FOREIGN KEY (StoreId)
    REFERENCES Stores(StoreId),

    CONSTRAINT FK_Stocks_Products
    FOREIGN KEY (ProductId)
    REFERENCES Products(ProductId)
);

--Insert sample data
INSERT INTO Stocks (StoreId, ProductId, Quantity)
VALUES
(1,1,0),
(1,2,10),
(1,3,5),
(2,1,3),
(2,2,0),
(2,4,8),
(3,1,2),
(3,3,0),
(3,5,6);


--OrderItems table
CREATE TABLE OrderItems
(
    OrderItemId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    ProductId INT,
    Quantity INT,
    Discount DECIMAL(10,2),

    CONSTRAINT FK_OrderItems_Orders
    FOREIGN KEY (OrderId)
    REFERENCES Orders(OrderId),

    CONSTRAINT FK_OrderItems_Products
    FOREIGN KEY (ProductId)
    REFERENCES Products(ProductId)
);

--Insert sample data
INSERT INTO OrderItems (OrderId, ProductId, Quantity, Discount)
VALUES
(1,1,2,20),
(1,3,1,5),
(2,2,1,10),
(2,4,1,15),
(3,5,2,25),
(3,6,1,10),
(4,1,1,20),
(4,7,1,50),
(5,8,1,100),
(5,9,1,150),
(6,10,2,10),
(6,11,1,5),
(7,12,1,8),
(8,3,2,5);

ALTER TABLE Orders
ADD StoreId INT;

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Stores
FOREIGN KEY (StoreId)
REFERENCES Stores(StoreId);

--📌 Requirements
--1. Identify products sold in each store using nested queries.
--2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
--3. Display store_name, product_name, total quantity sold.
--4. Calculate total revenue per product (quantity × list_price – discount).
--5. Update stock quantity to 0 for discontinued products (simulation).

SELECT 
    s.StoreName,
    p.ProductName,
    SUM(oi.Quantity) AS TotalQuantitySold,
    SUM((oi.Quantity * p.ListPrice) - oi.Discount) AS TotalRevenue
FROM
(
    SELECT StoreId, ProductId
    FROM
    (
        SELECT o.StoreId, oi.ProductId
        FROM Orders o
        JOIN OrderItems oi
            ON o.OrderId = oi.OrderId
    ) SoldProducts
    EXCEPT
    SELECT StoreId, ProductId
    FROM Stocks
    WHERE Quantity > 0
) AS OutOfStockSoldProducts
JOIN Orders o
    ON OutOfStockSoldProducts.StoreId = o.StoreId
JOIN OrderItems oi
    ON o.OrderId = oi.OrderId
    AND oi.ProductId = OutOfStockSoldProducts.ProductId
JOIN Stores s
    ON s.StoreId = o.StoreId
JOIN Products p
    ON p.ProductId = oi.ProductId
GROUP BY 
    s.StoreName,
    p.ProductName
ORDER BY 
    s.StoreName,
    p.ProductName;

	--Level-2: Problem 4 – Order Cleanup and Data Maintenance

ALTER TABLE Orders
ADD RequiredDate DATE,
    ShippedDate DATE,
    OrderStatus INT;

UPDATE Orders
SET RequiredDate = DATEADD(DAY,5,OrderDate),
    ShippedDate = DATEADD(DAY,3,OrderDate),
    OrderStatus = 2
WHERE OrderId IN (1,2,3,4);

UPDATE Orders
SET RequiredDate = DATEADD(DAY,5,OrderDate),
    ShippedDate = DATEADD(DAY,7,OrderDate),
    OrderStatus = 3
WHERE OrderId IN (5,6);

UPDATE Orders
SET RequiredDate = DATEADD(DAY,5,OrderDate),
    ShippedDate = DATEADD(DAY,4,OrderDate),
    OrderStatus = 2
WHERE OrderId IN (7,8);

CREATE TABLE Archived_Orders
(
    OrderId INT,
    CustomerId INT,
    OrderDate DATE,
    RequiredDate DATE,
    ShippedDate DATE,
    OrderStatus INT
);


BEGIN TRANSACTION

-- 1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.

INSERT INTO Archived_Orders
SELECT 
    OrderId,
    CustomerId,
    OrderDate,
    RequiredDate,
    ShippedDate,
    OrderStatus
FROM Orders
WHERE OrderStatus = 3
AND OrderDate < DATEADD(YEAR,-1,GETDATE());


--2. Delete orders where order_status = 3 (Rejected) and older than 1 year.

DELETE FROM Orders
WHERE OrderStatus = 3
AND OrderDate < DATEADD(YEAR,-1,GETDATE());


-- 3. Use nested query to identify customers whose all orders are completed.
SELECT 
    c.CustomerId,
    CONCAT(c.FirstName,' ',c.LastName) AS CustomerName
FROM Customers c
WHERE c.CustomerId NOT IN
(
    SELECT CustomerId
    FROM Orders
    WHERE OrderStatus <> 2
);


--4. Display order processing delay (DATEDIFF between shipped_date and order_date).

SELECT 
    OrderId,
    OrderDate,
    ShippedDate,
    DATEDIFF(DAY,OrderDate,ShippedDate) AS ProcessingDelay
FROM Orders;


-- 5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date. 
SELECT 
    OrderId,
    OrderDate,
    RequiredDate,
    ShippedDate,
    CASE
        WHEN ShippedDate > RequiredDate THEN 'Delayed'
        ELSE 'On Time'
    END AS DeliveryStatus
FROM Orders;

COMMIT;