USE RetailDB;

--Level-2 Problem 3: Cursor-Based Revenue Calculation

--Use a cursor to iterate through completed orders (order_status = 4).
-- Calculate total revenue per order using order_items.
-- Store computed revenue in a temporary table.

-- Temporary table to store revenue per order
CREATE TABLE #OrderRevenue
(
    OrderID INT,
    StoreID INT,
    Revenue DECIMAL(10,2)
);

DECLARE 
    @OrderID INT,
    @StoreID INT,
    @Revenue DECIMAL(10,2);

BEGIN TRY
    BEGIN TRANSACTION;
    -- Cursor for completed orders
    DECLARE OrderCursor CURSOR FOR
    SELECT OrderID, StoreID
    FROM Orders
    WHERE OrderStatus = 4;

    OPEN OrderCursor;

    FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @Revenue = SUM(Quantity * ListPrice * (1 - Discount/100.0))
        FROM OrderItems
        WHERE OrderID = @OrderID;

        INSERT INTO #OrderRevenue
        VALUES(@OrderID, @StoreID, ISNULL(@Revenue,0));

        FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID;
    END
    CLOSE OrderCursor;
    DEALLOCATE OrderCursor;

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT ERROR_MESSAGE();
END CATCH;

-- Store-wise revenue summary
SELECT 
    StoreID,
    SUM(Revenue) AS TotalRevenue
FROM #OrderRevenue
GROUP BY StoreID;

