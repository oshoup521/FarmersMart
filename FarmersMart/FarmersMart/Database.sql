create database if not exists farmersmart;
use farmersmart;

CREATE TABLE Admin (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Category (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Description TEXT
);

CREATE TABLE Product (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    ImageUrl VARCHAR(255) NOT NULL,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

CREATE TABLE Supplier (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Phone VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    ProductId INT,
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);


CREATE TABLE Customer (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Phone VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Cart (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId VARCHAR(255) NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL
);

CREATE TABLE CartItem (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    CartId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CartId) REFERENCES Cart(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE `Order` (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId VARCHAR(255) NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    ShippingAddress VARCHAR(255) NOT NULL
);

CREATE TABLE OrderDetails (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES `Order`(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

DELIMITER $$
CREATE PROCEDURE AddProduct (IN p_name VARCHAR(255), IN p_description TEXT, IN p_price DECIMAL(10,2), IN p_imageUrl VARCHAR(255), IN p_categoryId INT)
BEGIN
    INSERT INTO Product (Name, Description, Price, ImageUrl, CategoryId) VALUES (p_name, p_description, p_price, p_imageUrl, p_categoryId);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE UpdateProduct (
    IN id INT,
    IN name VARCHAR(255),
    IN description TEXT,
    IN price DECIMAL(10, 2),
    IN imageUrl VARCHAR(255),
    IN categoryId INT
)
BEGIN
    UPDATE Product
    SET Name = name, Description = description, Price = price, ImageUrl = imageUrl, CategoryId = categoryId
    WHERE Id = id;
END$$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE DeleteProduct (IN id INT)
BEGIN
    DELETE FROM Product WHERE Id = id;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE GetProductsByCategory (IN categoryId INT)
BEGIN
    SELECT * FROM Product WHERE CategoryId = categoryId;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE GetOrderDetails (IN orderId INT)
BEGIN
    SELECT * FROM OrderDetails WHERE OrderId = orderId;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE AddOrder (
    IN userId VARCHAR(255),
    IN orderDate DATETIME,
    IN totalPrice DECIMAL(10, 2),
    IN shippingAddress VARCHAR(255)
)
BEGIN
    INSERT INTO `Order` (UserId, OrderDate, TotalPrice, ShippingAddress)
    VALUES (userId, orderDate, totalPrice, shippingAddress);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE UpdateOrder (
    IN id INT,
    IN userId VARCHAR(255),
    IN orderDate DATETIME,
    IN totalPrice DECIMAL(10, 2),
    IN shippingAddress VARCHAR(255)
)
BEGIN
    UPDATE `Order`
    SET UserId = userId, OrderDate = orderDate, TotalPrice = totalPrice, ShippingAddress = shippingAddress
    WHERE Id = id;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DeleteOrder (IN id INT)
BEGIN
    DELETE FROM `Order` WHERE Id = id;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE AddCartItem (
    IN cartId INT,
    IN productId INT,
    IN quantity INT,
    IN price DECIMAL(10, 2)
)
BEGIN
    INSERT INTO CartItem (CartId, ProductId, Quantity, Price)
    VALUES (cartId, productId, quantity, price);
END$$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE UpdateCartItem (
    IN id INT,
    IN cartId INT,
    IN productId INT,
    IN quantity INT,
    IN price DECIMAL(10, 2)
)
BEGIN
    UPDATE CartItem
    SET CartId = cartId, ProductId = productId, Quantity = quantity, Price = price
    WHERE Id = id;
END$$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE DeleteCartItem (IN id INT)
BEGIN
    DELETE FROM CartItem WHERE Id = id;
END$$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE GetCustomerDetails (IN userId VARCHAR(255))
BEGIN
    SELECT * FROM Customer WHERE UserId = userId;
END$$
DELIMITER ;


INSERT INTO Admin (UserName, Email, Password) VALUES
    ('osho', 'osho@gmail.com', '12345'),
    ('ashutosh', 'ashutosh@gmail.com', '12345'),
    ('bhatt', 'bhatt@gmail.com', '12345');

INSERT INTO Category (Name, Description) VALUES 
    ('Category 1', 'This is the first category'), 
    ('Category 2', 'This is the second category'), 
    ('Category 3', 'This is the third category');


INSERT INTO Product (Name, Description, Price, ImageUrl, CategoryId) VALUES 
    ('Product 1', 'This is the first product', 19.99, 'product1.jpg', 1), 
    ('Product 2', 'This is the second product', 29.99, 'product2.jpg', 2), 
    ('Product 3', 'This is the third product', 39.99, 'product3.jpg', 3);

INSERT INTO Customer (UserId, FirstName, LastName, Email, Phone, Password) VALUES 
    ('user1', 'John', 'Doe', 'johndoe@example.com', '555-555-5555', 'password1'), 
    ('user2', 'Jane', 'Doe', 'janedoe@example.com', '555-555-5556', 'password2'), 
    ('user3', 'Bob', 'Smith', 'bobsmith@example.com', '555-555-5557', 'password3');

INSERT INTO Supplier (Name, Email, Phone, Password, ProductId) VALUES 
    ('Supplier 1', 'supplier1@example.com', '555-555-5555', 'password1', 1), 
    ('Supplier 2', 'supplier2@example.com', '555-555-5556', 'password2', 2), 
    ('Supplier 3', 'supplier3@example.com', '555-555-5557', 'password3', 3);


