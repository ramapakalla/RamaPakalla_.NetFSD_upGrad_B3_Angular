--Level-2 Problem 3: Order Status Validation Trigger

Use RetailDB


-- Create an AFTER UPDATE trigger on orders.
-- Validate that shipped_date is NOT NULL when order_status = 4.
-- Prevent update if condition fails.

CREATE TRIGGER trg_ValidateOrderStatus
ON Orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        IF EXISTS (
            SELECT 1
            FROM Inserted I
            WHERE I.OrderStatus = 4
            AND I.ShippedDate IS NULL
        )
        BEGIN
            THROW 50001, 'Order cannot be marked as Completed when ShippedDate is NULL.', 1;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

--Test:
-- Invalid update 
UPDATE Orders
SET OrderStatus = 4,
    ShippedDate = NULL
WHERE OrderID = 1;

-- Valid update 
UPDATE Orders
SET OrderStatus = 4,
    ShippedDate = '2025-02-03'
WHERE OrderID = 1;

-- Check result
SELECT * FROM Orders WHERE OrderID = 1;