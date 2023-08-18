create database ProductInventoryDB
use ProductInventoryDB

create table Products
(ProductId int primary key identity,
ProductName nvarchar(50) not null,
Price float not null,
Quantity int not null,
MFDate date,
ExpDate date)

insert into Products values('Shampoo', 5.25, 30, '08/05/2023', '09/05/2023')
select * from Products