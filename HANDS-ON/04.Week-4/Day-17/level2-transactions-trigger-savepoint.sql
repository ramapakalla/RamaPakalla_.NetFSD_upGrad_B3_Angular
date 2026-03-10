--Level-2 Problem 1: Transactions and Trigger Implementation

USE RetailDB

-- Create a trigger to reduce stock quantity after order insertion.
CREATE TRIGGER trg_UpdateStock
ON OrderItems
AFTER INSERT
AS
BEGIN
    --Check stock availability before confirming order.
    IF EXISTS (
        SELECT 1
        FROM Stocks s
        JOIN Orders o ON s.StoreId = o.StoreId
        JOIN Inserted i ON i.ProductId = s.ProductId AND i.OrderId = o.OrderId
        WHERE s.Quantity < i.Quantity
    )
    BEGIN
        RAISERROR ('Insufficient Stock Available',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce Stock
    UPDATE S
    SET s.Quantity = s.Quantity - i.Quantity
    FROM Stocks s
    JOIN Orders o ON s.StoreId = o.StoreId
    JOIN Inserted i ON i.ProductId = s.ProductId AND i.OrderId = o.OrderId;

END;

-- Write a transaction to insert data into orders and order_items tables.
BEGIN TRANSACTION;

BEGIN TRY
    DECLARE @OrderId INT;

    -- Insert Order
    INSERT INTO Orders(CustomerId, StoreId, OrderDate, OrderStatus)
    VALUES (1,1,GETDATE(),1);
    -- Insert Order Items
    INSERT INTO OrderItems(OrderId, ProductId, Quantity, ListPrice, Discount)
    VALUES
    (@OrderId,1,2,70000,10),
    (@OrderId,5,3,3000,5);
    COMMIT TRANSACTION;
    PRINT 'Order Placed Successfully';
END TRY

BEGIN CATCH
    --Rollback transaction if stock quantity is insufficient.
    ROLLBACK TRANSACTION;
    PRINT 'Order Failed Due To Insufficient Stock';
END CATCH;






--Level-2 Problem 2: Atomic Order Cancellation with SAVEPOINT

-- Begin a transaction when cancelling an order.
DECLARE @OrderId INT = 2;
BEGIN TRANSACTION;
BEGIN TRY
    --Use SAVEPOINT before stock restoration.
    SAVE TRANSACTION RestoreStockSavePoint;

    -- Restore stock quantities based on order_items.
    UPDATE s
    SET s.Quantity = s.Quantity + oi.Quantity
    FROM Stocks AS s
    INNER JOIN OrderItems AS oi
        ON s.ProductId = oi.ProductId
    WHERE oi.OrderId = @OrderId;

    -- Update order_status to 3 (Rejected)
    UPDATE Orders
    SET OrderStatus = 3
    WHERE OrderId = @OrderId;

    -- Commit transaction only if all operations succeed.
    COMMIT TRANSACTION;
    PRINT 'Order Cancelled And Stock Restored Successfully';

END TRY

BEGIN CATCH
    -- Rollback to savepoint if stock restoration fails
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION RestoreStockSavePoint;

    PRINT 'Error Occurred During Order Cancellation';

    PRINT ERROR_MESSAGE();

    -- Rollback remaining transaction
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

END CATCH;