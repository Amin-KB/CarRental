kill 56
GO
CREATE DATABASE CarRental

GO

USE CarRental

GO
CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL,
Phone VARCHAR(24) NOT NULL,
Address NVARCHAR(200),
City NVARCHAR(30),
Postal VARCHAR(20),
Region NVARCHAR(20),
Country NVARCHAR(20),
)

CREATE INDEX IX_Customers_Id ON Customers (CustomerID);
CREATE INDEX IX_Customers_Email ON Customers (Email);
CREATE INDEX IX_Customers_Phone ON Customers (Phone);
GO

CREATE TABLE Cars (
    CarID INT PRIMARY KEY,
    Make VARCHAR(50),
    Model VARCHAR(50),
    Year INT,
    Mileage INT,
	RentalStatus BIT DEFAULT 0
);


GO
CREATE INDEX IX_Cars_Make ON Cars (Make);
CREATE INDEX IX_Cars_Model ON Cars (Model);
GO
CREATE TABLE Rentals (
    RentalID INT PRIMARY KEY,
    CustomerID INT,
    CarID INT,
    RentalDate DATETIME,
    ReturnDate DATETIME,
    KilometersDriven INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (CarID) REFERENCES Cars(CarID)
);

GO
CREATE INDEX IX_Rentals_CustomerID ON Rentals (CustomerID);
CREATE INDEX IX_Rentals_CarID ON Rentals (CarID);
CREATE INDEX IX_Rentals_RentalDate ON Rentals (RentalDate);
CREATE INDEX IX_Rentals_ReturnDate ON Rentals (ReturnDate);
GO
CREATE TABLE RentedCars (
    RentalID INT,
    CarID INT,
    PRIMARY KEY (RentalID, CarID),
    FOREIGN KEY (RentalID) REFERENCES Rentals(RentalID),
    FOREIGN KEY (CarID) REFERENCES Cars(CarID)
);