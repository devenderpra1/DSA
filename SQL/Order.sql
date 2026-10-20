
-- Clean up tables if they already exist
DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS Orders;

-- Parent table
CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    OrderDate DATE,
    Status VARCHAR(20)
);

-- Child table
CREATE TABLE OrderItems
(
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    ProductName VARCHAR(50),
    Quantity INT,
    Price DECIMAL(10, 2),

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- Insert orders
INSERT INTO Orders
    (OrderID, CustomerName, OrderDate, Status)
VALUES
    (1, 'Rahul', '2026-10-01', 'Completed'),
    (2, 'Priya', '2026-10-02', 'Completed'),
    (3, 'Amit',  '2026-10-03', 'Pending'),
    (4, 'Neha',  '2026-10-04', 'Completed'),
    (5, 'Vijay', '2026-10-05', 'Pending');

-- Insert order items
INSERT INTO OrderItems
    (OrderItemID, OrderID, ProductName, Quantity, Price)
VALUES
    (101, 1, 'Laptop',   1, 60000),
    (102, 1, 'Mouse',    2,   500),
    (103, 2, 'Keyboard', 1,  1500),
    (104, 2, 'Mouse',    1,   500),
    (105, 3, 'Monitor',  2, 12000),
    (106, 3, 'Laptop',   1, 60000),
    (107, 5, 'Mouse',    3,   500);

Select *
From OrderItems oItems join Orders actOrder
On oItems.OrderID = actOrder.OrderID
Where Status != 'Pending'
And Price >500

Select *
From Orders o Left Join OrderItems item
On o.OrderID = item.OrderID
Where OrderItemID IS NULL


