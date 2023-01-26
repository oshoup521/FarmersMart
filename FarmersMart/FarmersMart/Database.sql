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

CREATE TABLE Admin (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);


CREATE TABLE Customer (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHARCHAR(255) NOT NULL,
    Phone VARCHAR(255) NOT NULL
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





CREATE PROCEDURE AddProduct (
    IN name VARCHAR(255), 
    IN description TEXT, 
    IN price DECIMAL(10, 2), 
    IN imageUrl VARCHAR(255),
    IN categoryId INT
)
BEGIN
    INSERT INTO Product (Name, Description, Price, ImageUrl, CategoryId)
    VALUES (name, description, price, imageUrl, categoryId);
END;



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
END;




CREATE PROCEDURE DeleteProduct (IN id INT)
BEGIN
    DELETE FROM Product WHERE Id = id;
END;



CREATE PROCEDURE GetProductsByCategory (IN categoryId INT)
BEGIN
    SELECT * FROM Product WHERE CategoryId = categoryId;
END;


CREATE PROCEDURE GetOrderDetails (IN orderId INT)
BEGIN
    SELECT * FROM OrderDetails WHERE OrderId = orderId;
END;



CREATE PROCEDURE AddOrder (
    IN userId VARCHAR(255), 
    IN orderDate DATETIME, 
    IN totalPrice DECIMAL(10, 2), 
    IN shippingAddress VARCHAR(255)
)
BEGIN
    INSERT INTO `Order` (UserId, OrderDate, TotalPrice, ShippingAddress)
    VALUES (userId, orderDate, totalPrice, shippingAddress);
END;




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
END;



CREATE PROCEDURE DeleteOrder (IN id INT)
BEGIN
    DELETE FROM `Order` WHERE Id = id;
END;



CREATE PROCEDURE AddCartItem (
    IN cartId INT, 
    IN productId INT, 
    IN quantity INT, 
    IN price DECIMAL(10, 2)
)
BEGIN
    INSERT INTO CartItem (CartId, ProductId, Quantity, Price)
    VALUES (cartId, productId, quantity, price);
END;



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
END;



CREATE PROCEDURE DeleteCartItem (IN id INT)
BEGIN
    DELETE FROM CartItem WHERE Id = id;
END;



CREATE PROCEDURE GetCustomerDetails (IN userId VARCHAR(255))
BEGIN
    SELECT * FROM Customer WHERE UserId = userId;
END;




