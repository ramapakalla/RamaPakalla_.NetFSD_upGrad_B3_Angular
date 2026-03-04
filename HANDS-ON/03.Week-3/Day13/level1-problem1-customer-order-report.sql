-- Create Database 
CREATE DATABASE OrdersDb;

USE OrdersDb;
--Create Table (Customers)
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);

--Storing sample data
INSERT INTO Customers (FirstName, LastName)
VALUES 
('Ravi', 'Kumar'),
('Anita', 'Sharma'),
('Kiran', 'Reddy'),
('Priya', 'Verma'),
('Arjun', 'Patel');

select * from customers

--Create Table (Orders)
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDate DATE NOT NULL,
    OrderStatus INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);


-- Storing sample data
INSERT INTO Orders (CustomerId, OrderDate, OrderStatus)
VALUES
(1, '2026-03-01', 1),
(2, '2026-03-02', 4),
(3, '2026-03-03', 2),
(4, '2026-03-04', 1),
(5, '2026-03-05', 4),
(1, '2026-03-06', 3),
(2, '2026-03-07', 4);

select * from orders;

-- 1. Retrieve customer first name, last name, order_id, order_date, and order_status.
-- 2.Display only orders with status Pending (1) or Completed (4).
--3. Sort the results by order_date in descending order.

SELECT 
    c.FirstName,
    c.LastName,
    o.OrderId,
    o.OrderDate,
    o.OrderStatus
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerId = o.CustomerId
WHERE o.OrderStatus = 1 
   OR o.OrderStatus = 4
ORDER BY o.OrderDate DESC;