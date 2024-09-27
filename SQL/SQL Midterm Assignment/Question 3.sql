-- Create Users table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    DateOfRegistration DATETIME NOT NULL,
    UserType NVARCHAR(50) NOT NULL CHECK (UserType IN ('Customer', 'Artisan'))
);

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    ShippingAddress NVARCHAR(255) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);

-- Create Artisans table
CREATE TABLE Artisans (
    ArtisanID INT PRIMARY KEY,
    StoreName NVARCHAR(100) NOT NULL,
    Bio NVARCHAR(500) NOT NULL,
    StoreContactDetails NVARCHAR(255) NOT NULL,
    FOREIGN KEY (ArtisanID) REFERENCES Users(UserID)
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    QuantityAvailable INT NOT NULL,
    DateAdded DATETIME NOT NULL,
    ArtisanID INT NOT NULL,
    FOREIGN KEY (ArtisanID) REFERENCES Artisans(ArtisanID)
);

-- Create ProductKeywords relationship table
CREATE TABLE ProductKeywords (
    ProductID INT NOT NULL,
    Keyword NVARCHAR(50) NOT NULL,
    PRIMARY KEY (ProductID, Keyword),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Collections table
CREATE TABLE Collections (
    CollectionID INT IDENTITY(1,1) PRIMARY KEY,
    CollectionName NVARCHAR(100) NOT NULL,
    ArtisanID INT NOT NULL,
    FOREIGN KEY (ArtisanID) REFERENCES Artisans(ArtisanID)
);

-- Create ProductCollections relationship table
CREATE TABLE ProductCollections (
    CollectionID INT NOT NULL,
    ProductID INT NOT NULL,
    PRIMARY KEY (CollectionID, ProductID),
    FOREIGN KEY (CollectionID) REFERENCES Collections(CollectionID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Carts table
CREATE TABLE Carts (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create CartItems relationship table
CREATE TABLE CartItems (
    CartID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    DateAdded DATETIME NOT NULL,
    PRIMARY KEY (CartID, ProductID),
    FOREIGN KEY (CartID) REFERENCES Carts(CartID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Transactions table
CREATE TABLE Transactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    DateOfPurchase DATETIME NOT NULL,
    CustomerID INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    ShippingAddress NVARCHAR(255) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create TransactionItems relationship table
CREATE TABLE TransactionItems (
    TransactionID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    PriceAtPurchase DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (TransactionID, ProductID),
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Shipments table
CREATE TABLE Shipments (
    ShippingID INT IDENTITY(1,1) PRIMARY KEY,
    TransactionID INT NOT NULL,
    TrackingNumber NVARCHAR(100) NOT NULL,
    ShipmentDate DATETIME NOT NULL,
    EstimatedDeliveryDate DATETIME NOT NULL,
    DeliveryStatus NVARCHAR(50) NOT NULL CHECK (DeliveryStatus IN ('Pending', 'Shipped', 'Delivered')),
    ShippingProvider NVARCHAR(50) NOT NULL,
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);

-- Create Reviews table
CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    ProductID INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    ReviewText NVARCHAR(1000) NOT NULL,
    ReviewTimestamp DATETIME NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    UNIQUE (CustomerID, ProductID) -- Ensure one review per product per customer
);

-- Create Promotions table
CREATE TABLE Promotions (
    PromotionID INT IDENTITY(1,1) PRIMARY KEY,
    PromotionName NVARCHAR(100) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    DiscountPercentage DECIMAL(5, 2) NOT NULL CHECK (DiscountPercentage BETWEEN 0 AND 100)
);

-- Create ProductPromotions relationship table
CREATE TABLE ProductPromotions (
    PromotionID INT NOT NULL,
    ProductID INT NOT NULL,
    PRIMARY KEY (PromotionID, ProductID),
    FOREIGN KEY (PromotionID) REFERENCES Promotions(PromotionID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create SupportTickets table
CREATE TABLE SupportTickets (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    TransactionID INT,
    IssueType NVARCHAR(50) NOT NULL,
    IssueDescription NVARCHAR(1000) NOT NULL,
    TicketStatus NVARCHAR(50) NOT NULL CHECK (TicketStatus IN ('Open', 'In Progress', 'Resolved')),
    DateSubmitted DATETIME NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);


------ INSERTIONS ------

INSERT INTO Users (Name, Email, Password, DateOfRegistration, UserType) VALUES
('Alice Johnson', 'alice.johnson@example.com', 'password123', '2024-01-01', 'Customer'),
('Bob Smith', 'bob.smith@example.com', 'password123', '2024-01-02', 'Customer'),
('Charlie Brown', 'charlie.brown@example.com', 'password123', '2024-01-03', 'Artisan'),
('Diana Prince', 'diana.prince@example.com', 'password123', '2024-01-04', 'Artisan'),
('Eve Adams', 'eve.adams@example.com', 'password123', '2024-01-05', 'Customer'),
('Frank Wright', 'frank.wright@example.com', 'password123', '2024-01-06', 'Customer'),
('Grace Lee', 'grace.lee@example.com', 'password123', '2024-01-07', 'Artisan'),
('Hank Green', 'hank.green@example.com', 'password123', '2024-01-08', 'Customer'),
('Ivy Clark', 'ivy.clark@example.com', 'password123', '2024-01-09', 'Customer'),
('Jack White', 'jack.white@example.com', 'password123', '2024-01-10', 'Artisan');

INSERT INTO Customers (CustomerID, ShippingAddress) VALUES
(1, '123 Main St, Springfield, IL'),
(2, '456 Oak St, Springfield, IL'),
(5, '789 Pine St, Springfield, IL'),
(6, '101 Maple St, Springfield, IL'),
(8, '202 Birch St, Springfield, IL'),
(9, '303 Cedar St, Springfield, IL');

INSERT INTO Artisans (ArtisanID, StoreName, Bio, StoreContactDetails) VALUES
(3, 'Charlie''s Crafts', 'Handmade crafts by Charlie Brown', 'charlie.brown@example.com'),
(4, 'Diana''s Designs', 'Unique designs by Diana Prince', 'diana.prince@example.com'),
(7, 'Grace''s Gallery', 'Art by Grace Lee', 'grace.lee@example.com'),
(10, 'Jack''s Jewelry', 'Jewelry by Jack White', 'jack.white@example.com');

INSERT INTO Products (ProductName, Description, Price, Category, QuantityAvailable, DateAdded, ArtisanID) VALUES
('Handmade Necklace', 'A beautiful handmade necklace', 29.99, 'Jewelry', 50, '2024-01-15', 3),
('Decorative Vase', 'A decorative vase for home decor', 49.99, 'Home Decor', 30, '2024-01-16', 4),
('Abstract Painting', 'An abstract painting for art lovers', 19.99, 'Art', 100, '2024-01-17', 7),
('Knitted Scarf', 'A warm knitted scarf', 39.99, 'Clothing', 20, '2024-01-18', 10),
('Wooden Toy', 'A handmade wooden toy', 59.99, 'Toys', 15, '2024-01-19', 3),
('Ceramic Plate', 'A ceramic plate for your kitchen', 34.99, 'Home Decor', 25, '2024-01-20', 4),
('Canvas Print', 'A canvas print for your wall', 24.99, 'Art', 40, '2024-01-21', 7),
('Beaded Bracelet', 'A beaded bracelet for fashion', 19.99, 'Jewelry', 100, '2024-01-22', 3),
('Woolen Hat', 'A woolen hat for winter', 79.99, 'Clothing', 10, '2024-01-23', 4),
('Silk Scarf', 'A silk scarf for elegance', 19.99, 'Clothing', 100, '2024-01-24', 10);

INSERT INTO ProductKeywords (ProductID, Keyword) VALUES
(1, 'handmade'),
(1, 'necklace'),
(2, 'decorative'),
(2, 'vase'),
(3, 'abstract'),
(3, 'painting'),
(4, 'knitted'),
(4, 'scarf'),
(5, 'wooden'),
(5, 'toy'),
(6, 'ceramic'),
(6, 'plate'),
(7, 'canvas'),
(7, 'print'),
(8, 'beaded'),
(8, 'bracelet'),
(9, 'woolen'),
(9, 'hat'),
(10, 'silk'),
(10, 'scarf');

INSERT INTO Collections (CollectionName, ArtisanID) VALUES
('Necklace Collection', 3),
('Vase Collection', 4),
('Painting Collection', 7),
('Scarf Collection', 10);

INSERT INTO ProductCollections (CollectionID, ProductID) VALUES
(1, 1),
(1, 8),
(2, 2),
(2, 6),
(3, 3),
(3, 7),
(4, 4),
(4, 9),
(4, 10);

INSERT INTO Carts (CustomerID) VALUES
(1),
(2),
(5),
(6),
(8),
(9);

INSERT INTO CartItems (CartID, ProductID, Quantity, DateAdded) VALUES
(1, 1, 2, '2024-01-25'),
(1, 2, 1, '2024-01-25'),
(2, 3, 1, '2024-01-26'),
(2, 4, 2, '2024-01-26'),
(3, 5, 1, '2024-01-27'),
(3, 6, 1, '2024-01-27'),
(4, 7, 3, '2024-01-28'),
(4, 8, 1, '2024-01-28'),
(5, 9, 2, '2024-01-29'),
(5, 10, 1, '2024-01-29');

INSERT INTO Transactions (DateOfPurchase, CustomerID, TotalAmount, PaymentMethod, ShippingAddress) VALUES
('2024-02-01', 1, 89.97, 'Credit Card', '123 Main St, Springfield, IL'),
('2024-02-02', 2, 79.98, 'PayPal', '456 Oak St, Springfield, IL'),
('2024-02-03', 5, 94.98, 'Credit Card', '789 Pine St, Springfield, IL'),
('2024-02-04', 6, 104.97, 'Credit Card', '101 Maple St, Springfield, IL'),
('2024-02-05', 8, 99.98, 'PayPal', '202 Birch St, Springfield, IL');

INSERT INTO TransactionItems (TransactionID, ProductID, Quantity, PriceAtPurchase) VALUES
(1, 1, 2, 29.99),
(1, 2, 1, 49.99),
(2, 3, 1, 19.99),
(2, 4, 2, 39.99),
(3, 5, 1, 59.99),
(3, 6, 1, 34.99),
(4, 7, 3, 24.99),
(4, 8, 1, 19.99),
(5, 9, 2, 79.99),
(5, 10, 1, 19.99);

INSERT INTO Shipments (TransactionID, TrackingNumber, ShipmentDate, EstimatedDeliveryDate, DeliveryStatus, ShippingProvider) VALUES
(1, 'TRACK12345', '2024-02-02', '2024-02-05', 'Shipped', 'FedEx'),
(2, 'TRACK12346', '2024-02-03', '2024-02-06', 'Shipped', 'UPS'),
(3, 'TRACK12347', '2024-02-04', '2024-02-07', 'Shipped', 'DHL'),
(4, 'TRACK12348', '2024-02-05', '2024-02-08', 'Shipped', 'FedEx'),
(5, 'TRACK12349', '2024-02-06', '2024-02-09', 'Shipped', 'UPS');

INSERT INTO Reviews (CustomerID, ProductID, Rating, ReviewText, ReviewTimestamp) VALUES
(1, 1, 5, 'Amazing necklace!', '2024-02-10'),
(1, 2, 4, 'Great vase!', '2024-02-11'),
(2, 3, 5, 'Love the painting!', '2024-02-12'),
(2, 4, 4, 'Nice scarf!', '2024-02-13'),
(5, 5, 5, 'Awesome toy!', '2024-02-14'),
(5, 6, 3, 'Good plate.', '2024-02-15'),
(6, 7, 4, 'Cool print!', '2024-02-16'),
(6, 8, 5, 'Great bracelet!', '2024-02-17'),
(8, 9, 5, 'Amazing hat!', '2024-02-18'),
(8, 10, 4, 'Nice scarf!', '2024-02-19');

INSERT INTO Promotions (PromotionName, StartDate, EndDate, DiscountPercentage) VALUES
('Winter Sale', '2024-01-01', '2024-01-31', 20.00),
('New User Discount', '2024-01-01', '2024-12-31', 10.00),
('Valentine''s Day Sale', '2024-02-10', '2024-02-14', 15.00),
('Spring Sale', '2024-03-01', '2024-03-31', 25.00),
('Summer Sale', '2024-06-01', '2024-06-30', 30.00);

INSERT INTO ProductPromotions (PromotionID, ProductID) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(4, 7),
(4, 8),
(5, 9),
(5, 10);

INSERT INTO SupportTickets (CustomerID, TransactionID, IssueType, IssueDescription, TicketStatus, DateSubmitted) VALUES
(1, 1, 'Order Problem', 'Item not received', 'Open', '2024-02-20'),
(2, 2, 'Payment Issue', 'Payment not processed', 'Resolved', '2024-02-21'),
(5, 3, 'Product Complaint', 'Damaged item', 'In Progress', '2024-02-22'),
(6, 4, 'Order Problem', 'Wrong item received', 'Open', '2024-02-23'),
(8, 5, 'Order Problem', 'Item not received', 'Resolved', '2024-02-24');

------ SELECTIONS ------

-- Select all records from Users table
SELECT * FROM Users;

-- Select all records from Customers table
SELECT * FROM Customers;

-- Select all records from Artisans table
SELECT * FROM Artisans;

-- Select all records from Products table
SELECT * FROM Products;

-- Select all records from ProductKeywords table
SELECT * FROM ProductKeywords;

-- Select all records from Collections table
SELECT * FROM Collections;

-- Select all records from ProductCollections table
SELECT * FROM ProductCollections;

-- Select all records from Carts table
SELECT * FROM Carts;

-- Select all records from CartItems table
SELECT * FROM CartItems;

-- Select all records from Transactions table
SELECT * FROM Transactions;

-- Select all records from TransactionItems table
SELECT * FROM TransactionItems;

-- Select all records from Shipments table
SELECT * FROM Shipments;

-- Select all records from Reviews table
SELECT * FROM Reviews;

-- Select all records from Promotions table
SELECT * FROM Promotions;

-- Select all records from ProductPromotions table
SELECT * FROM ProductPromotions;

-- Select all records from SupportTickets table
SELECT * FROM SupportTickets;
