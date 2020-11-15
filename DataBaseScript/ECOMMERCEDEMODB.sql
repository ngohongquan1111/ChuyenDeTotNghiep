--(1) Accounts: AccountId, EmailLogin, AccountStatusID, Password, PassWordSalt , CreatedDate, LastLoginDate, AccountRoleId.
--(2’) Contacts: Contacts: ContactId, AccountId, ContactTypeId, ContactName, ContactEmail, ContactAddress, ContactPhoneNumber, ContactIdNumber, ContactStatusId.
--(3’’) Products: ProductID, ProducerId, ProducerId, ProductTypeId, PromotionId ,ProductName,ProductStatusId, CreatedDate, LastModified, Description, Price.
--(4’’’) Invoice : InvoiceId, InvoiceParentId, ContactId, WarehouseId,Amount,AmountNoVat ,VAT, CreatedDate, InvoiceStatusId, PaymentMenthodId, InvoicePaid.
--(5) Warehouses: WarehouseId, ProvinceId, CityId, DistrictId, SubDistrictId, FullPath , WareHouseStatus.
--(6) Promotions:  PromotionId, PromotionType, CreatedDate, StartTime, ExpiredDate.
--(7) Producers: ProducerId, Location.
--(8)  AccountStatus  : AccountStatusId, AccountStatusName.
--(9)  AccountRole    : AccountRoleId, AccountRoleName.
--(10) ContactType    : ContactTypeID, ContactTypeName.
--(11) ContactStatus  : ContactStatusId, ContactStatus.
--(12) ProductType    : ProductTypeId, ProductTypeName.
--(13) ProductStatus  : ProductStatusId, ProductStatusName.
--(14) InvoiceStatus  : InvoiceStatusId, InvoiceStatusName
--(15) PaymentMenthod : PaymentMenthodId, PaymentMenthodName.
--(16) PromotionType  : PromotionTypeId, PromotionTypeName
--(17) Orders: OrderId, ProductId, InvoiceId, Quantity.
--(18) WarehouseDetail: WarehouseDetailId, ProductId, WareHouseId, Quantity.

--DROP DATABASE ECOMMERCEDEMO;
--CREATE DATABASE ECOMMERCEDEMO;
--USE ECOMMERCEDEMO




CREATE DATABASE ECOMMERCEDEMO;
USE ECOMMERCEDEMO

 --CREATE TABLE ACCOUNTSTATUS  (AccountStatusID  int not null PRIMARY KEY IDENTITY(1,1), AccountStatusName NVARCHAR(100))
 CREATE TABLE AccountRole   ( AccountRoleId  int not null PRIMARY KEY IDENTITY(1,1), AccountRoleName Nvarchar(100))
 CREATE TABLE CONTACTTYPE   ( ContactTypeId  int not null PRIMARY KEY IDENTITY(1,1), ContactTypeName Nvarchar(100))
 CREATE TABLE ContactStatus ( ContactStatusId  int not null PRIMARY KEY IDENTITY(1,1), ContactStatus  Nvarchar(100))
 CREATE TABLE ProductType   ( ProductTypeId int not null PRIMARY KEY IDENTITY(1,1), ProductTypeName Nvarchar(100))
 CREATE TABLE ProductStatus ( ProductStatusId int not null PRIMARY KEY IDENTITY(1,1), ProductStatusName Nvarchar(100))
 CREATE TABLE InvoiceStatus ( InvoiceStatusId int not null PRIMARY KEY IDENTITY(1,1), InvoiceStatusName Nvarchar(100))
 CREATE TABLE PaymentMenthod( PaymentMenthodId int not null PRIMARY KEY IDENTITY(1,1), PaymentMenthodName Nvarchar(100))
 CREATE TABLE PromotionType ( PromotionTypeId int not null PRIMARY KEY IDENTITY(1,1), PromotionTypeName Nvarchar(100) )

CREATE TABLE Accounts (
 AccountId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
 EmailLogin NVARCHAR(100) NOT null, 
 --AccountStatusID INT ,-- FOREIGN KEY REFERENCES AccountStatus(AccountStatusId), 
 Password NVARCHAR(100) NOT null, 
 PassWordSalt NVARCHAR(100) , 
 CreatedDate DATETIME2, 
 LastLoginDate DATETIME2, 
 AccountRoleId INT -- FOREIGN KEY REFERENCES AccountRole(AccountRoleId)
 )

 CREATE TABLE Contacts 
 ( 
 ContactId  int not null PRIMARY KEY IDENTITY(1,1), 
 AccountId int ,-- FOREIGN KEY REFERENCES Accounts(AccountId), 
 ContactTypeId INT, -- FOREIGN KEY REFERENCES ContactType(ContactTypeID), 
 ContactName NVARCHAR(100), 
 ContactEmail  NVARCHAR(100), 
 ContactAddress  NVARCHAR(100), 
 ContactPhoneNumber  NVARCHAR(100), 
 ContactIdNumber  NVARCHAR(100), 
 ContactStatusId INT -- FOREIGN KEY REFERENCES ContactStatus(ContactStatusId))

 CREATE table Producers(
ProducerId  int not null PRIMARY KEY IDENTITY(1,1),
ProducerName nvarchar(100),
MadeInCountryId int
)
Create table MadeInCountry(
MadeInCountryId int not null primary key identity (1,1),
CountryName varchar(199),
)

-- CREATE TABLE Warehouses
--(WarehouseId  int not null PRIMARY KEY IDENTITY(1,1), 
-- ProvinceId int, 
-- CityId int, 
-- DistrictId int, 
-- SubDistrictId int, 
-- FullPath NVARCHAR(100), 
-- WareHouseStatus INT 
-- )

 --CREATE TABLE Promotions(  
 --PromotionId  int not null PRIMARY KEY IDENTITY(1,1), 
 --PromotionType INT, -- FOREIGN KEY REFERENCES PromotionType(PromotionTypeId), 
 --CreatedDate DATETIME2, 
 --StartTime DATETIME2, 
 --ExpiredDate DATETIME2)


 CREATE TABLE Products (
 ProductID  INT not null PRIMARY KEY IDENTITY(1,1), 
 ProducerId INT, -- FOREIGN KEY REFERENCES Producers(ProducerID), 
 ProductTypeId INT, -- FOREIGN KEY REFERENCES ProductType(ProductTypeId), 
 --PromotionId  int ,-- FOREIGN KEY REFERENCES Promotions(PromotionId),
 ProductName NVARCHAR(100),
 Quantity int,
 ProductStatusId int ,-- FOREIGN KEY REFERENCES ProductStatus(ProductStatusId), 
 CreatedDate DATETIME2, 
 LastModified DATETIME2, 
 Description NVARCHAR(100), 
 Price bigint not null,
 ImageURL NVARCHAR(500),
 ColorId int, 
 MaterialId int,
 BrandId int,
 )
 select * from Products


CREATE TABLE Invoices ( 
InvoiceId  int not null PRIMARY KEY IDENTITY(1,1),
--InvoiceParentId INT, 
ContactId INT,-- FOREIGN KEY REFERENCES Contacts(ContactId), 
--WarehouseId INT,-- FOREIGN KEY REFERENCES Warehouses(WarehouseId),
Amount BIGINT,
--AmountNoVat BIGINT,
--VAT FLOAT, 
CreatedDate DATETIME2, 
InvoiceStatusId INT,-- FOREIGN KEY REFERENCES InvoiceStatus(InvoiceStatusId),
PaymentMenthodId INT,-- FOREIGN KEY REFERENCES PaymentMenthod(PaymentMenthodId),
--InvoicePaid int
)



 CREATE table Orders 
 ( 
 OrderId  int not null PRIMARY KEY IDENTITY(1,1),
 ProductID INT,-- FOREIGN KEY REFERENCES Products(ProductID),
 InvoiceId INT,-- FOREIGN KEY REFERENCES Invoices(InvoiceId), 
 Quantity int )

 --CREATE TABLE WarehouseDetail (
 --WarehouseDetailId  int not null PRIMARY KEY IDENTITY(1,1), 
 --ProductID INT, -- FOREIGN KEY REFERENCES Products(ProductID), 
 --WarehouseId INT, -- FOREIGN KEY REFERENCES Warehouses(WarehouseId), 
 --Quantity int )


 SELECT * FROM Products;

 CREATE TABLE Allcode(
Id int identity (1,1),
IdentitySpace nvarchar(100),
IdentityScope nvarchar(100),
IdentityValueName nvarchar(199),
IdentityValue int
 )

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountRole', 'Administrator', 0);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountRole', 'Customer', 1);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountStatusId', 'Default', 0);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountStatusId', 'Verified', 1);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountStatusId', 'Deleted', 2);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Account', 'AccountStatusId', 'Locked', 3);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductStatus', 'Sale', 3);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductStatus', 'Suspended', 3);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductStatus', 'OutOfStock', 3);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductStatus', 'Deleted', 3);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Producer', 'VietNam', 0);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Producer', 'Trung Quoc', 1);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Producer', 'Lao', 2);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Producer', 'Han Quoc', 3);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Producer', 'Thai lan', 4);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Nước hoa', 0);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Son môi', 1);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Tẩy trang', 2);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Phấn trang điểm', 3);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Dụng cụ làm đẹp', 4);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Thuốc dưỡng', 5);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Sữa rửa mật', 6);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'ProductType', N'Chăm sóc tóc', 7);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Marterial', N'Nguyên liệu tự nhiên', 0);
--	INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Marterial', N'Chế phẩm', 1);


--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Đỏ', 0);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Xanh', 1);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Vàng', 2);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Lục', 3);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Lam', 4);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Chàm', 5);
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Color', N'Tím', 6);

--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Loreal', 0);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Clinique', 1);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'MAC', 2);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Shu Uemura', 3);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'SK-II', 4);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Olay', 5);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Revlon', 6);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Estee Lauder', 7);
	
--INSERT INTO Allcode (IdentitySpace, IdentityScope, IdentityValueName, IdentityValue)
--	VALUES ('Product', 'Brand', N'Dove', 8);
	

select * from Allcode where IdentitySpace = 'Product'

