CREATE TABLE Customers
(
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    Fullname VARCHAR(100),
    PhoneNumber VARCHAR(15),
    RegisterDate DATETIME
);

CREATE TABLE ComicBooks
(
    ComicBookId INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100),
    Author VARCHAR(100),
    Price DECIMAL(10, 2)
);

CREATE TABLE Rentals
(
    RentalId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT,
    RentalDate DATETIME,
    ReturnDate DATETIME,
    Status INT,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

CREATE TABLE RentalDetails
(
    RentalDetailId INT IDENTITY(1,1) PRIMARY KEY,
    RentalId INT,
    ComicBookId INT,
    Quantity INT,
    PricePerDay DECIMAL(10, 2),
    FOREIGN KEY (RentalId) REFERENCES Rentals(RentalId),
    FOREIGN KEY (ComicBookId) REFERENCES ComicBooks(ComicBookId)
);