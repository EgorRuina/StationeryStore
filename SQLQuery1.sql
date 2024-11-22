use StoreDB

--create table Products(
--ProductID int identity (1,1) primary key,
--ProductName nvarchar(100) not null,
--ProductType nvarchar(50) not null,
--Amount int not null,
--ProductValue decimal(10, 2) not null);

--create table SalesManagers(
--ManagerID int identity(1,1) primary key,
--ManagerName nvarchar(100) not null);

--create table Companies(
--CompanyID int identity(1,1) primary key,
--CompanyName nvarchar(100) not null);

--create table Sales(
--SaleID int identity(1,1) primary key,
--ProductID int not null,
--CompanyID int not null,
--ManagerID int not null,
--AmountSold int not null,
--PricePerUnit decimal(10, 2) not null,
--SaleDate datetime not null default getdate(),
--foreign key (ProductID) references Products(ProductID),
--foreign key (CompanyID) references Companies(CompanyID),
--foreign key (ManagerID) references SalesManagers(ManagerID));


--insert into Products(ProductName, ProductType, Amount, ProductValue)
--values
--('Notebook', 'Stationery', 150, 2.50),
--('Ballpoint Pen', 'Stationery', 200, 1.20),
--('Highlighter', 'Stationery', 100, 0.80),
--('Sticky Notes', 'Stationery', 75, 3.00),
--('Whiteboard Marker', 'Stationery', 50, 1.50);

--insert into SalesManagers (ManagerName)
--values
--('Alice Johnson'),
--('Bob Smith'),
--('Charlie Brown'),
--('Diana Prince');

--insert into Companies(CompanyName)
--values
--('Acme Corp.'),
--('Globex Corp.'),
--('Initech'),
--('Hooli');

--insert into Sales(ProductID, CompanyID, ManagerID, AmountSold, PricePerUnit ,SaleDate)
--values
--(1, 1, 1, 10, 2.50, '2024-11-01'),
--(2, 2, 2, 15, 1.20, '2024-11-02'),
--(3, 3, 3, 5, 0.80, '2024-11-03'),
--(1, 1, 1, 5, 2.50, '2024-11-04'),
--(2, 3, 2, 10, 1.20, '2024-11-05'),
--(4, 4, 4, 20, 3.00, '2024-11-06');


