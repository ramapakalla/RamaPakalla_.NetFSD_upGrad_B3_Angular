Use RetailDB

--Level-2 Problem 2: Stock Auto-Update Trigger

--- Create an AFTER INSERT trigger on order_items.

SELECT * FROM OrderItems
	
CREATE TRIGGER trg_afterInsertOrderItems
ON OrderItems
AFTER INSERT
AS
BEGIN TRY
    DECLARE @ProductId INT
    DECLARE @Quantity INT
    DECLARE @AvailableStock INT

    -- Get inserted values
    SELECT 
        @ProductId = ProductId,
        @Quantity = Quantity
    FROM INSERTED;

    -- Get stock quantity
    SELECT @AvailableStock = Quantity
    FROM Stocks
    WHERE ProductId = @ProductId;

    -- Prevent negative stock
    IF(@AvailableStock < @Quantity)
    BEGIN
        THROW 50001, 'Stock is insufficient for this product', 1;
    END

    -- Reduce stock
    UPDATE Stocks
    SET Quantity = Quantity - @Quantity
    WHERE ProductId = @ProductId;

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
	THROW;
END CATCH
END;

--Test
-- More quantity
INSERT INTO OrderItems
(OrderId, ProductId, Quantity, ListPrice, Discount)
VALUES
(1,2,60,70000,10);

SELECT ProductId, Quantity
FROM Stocks
WHERE ProductId = 2;

--less quantity
INSERT INTO OrderItems
(OrderId, ProductId, Quantity, ListPrice, Discount)
VALUES
(1,2,2,70000,2);





