create database ProductDB;

USE ProductDB;

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

SELECT * FROM Products;
--- Stored Procedure – Insert Product
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price);
END


CREATE PROCEDURE GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductId=@ProductId;
END


---Stored Procedure – Get All Products
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END



---Stored Procedure – Update Product
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END




---Stored Procedure – Delete Product
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
END


---Stored Procedure – Delete Product
CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT *  FROM Products
    WHERE ProductId = @ProductId;
END


