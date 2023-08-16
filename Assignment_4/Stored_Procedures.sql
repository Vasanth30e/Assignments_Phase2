create database Assesment04Db
use Assesment04Db

create table Products
(PId int primary key identity(500,1),
PName nvarchar(50) not null,
PPrice float not null,
PTax as PPrice*0.10 persisted,
PCompany nvarchar(50) unique not null,
PQty int check (PQty>=1) default 10)

insert into Products values ('TV', 50000.50, 'Samsung', 8),
('Laptop', 200000.20, 'Apple', 3),
('Smartphone', 25000.40, 'Redmi', 15)
insert into Products(PName, PPrice, PCompany) values ('Smartphone', 20000.20, 'HTC')
insert into Products values ('Headphone', 1500.15, 'Realme', 18)
insert into Products values('Tablet', 26000.30, 'Xioami', 12)

select * from Products

create proc usp_displayDetails
as
select PId, PName, (PTax+PPrice) PriceWithTax, PCompany, (PQty*(PTax+PPrice)) as TotalPrice from Products

alter proc usp_displayDetails
with encryption
as
select PId, PName, (PTax+PPrice) PriceWithTax, PCompany, (PQty*(PTax+PPrice)) as TotalPrice from Products

execute sp_helptext usp_displayDetails
exec usp_displayDetails

create proc usp_getTotalTaxByCompany
@pCompany nvarchar(50),
@totalTax float output
with encryption
as
select @totalTax = SUM(PTax)
from Products
where PCompany = @pCompany

declare @totalTaxOutput float
exec usp_getTotalTaxByCompany
@pCompany = 'Redmi', @totalTax = @totalTaxOutput output;
print @totalTaxOutput

declare @totalTaxOutput float
exec usp_getTotalTaxByCompany
@pCompany = 'Samsung', @totalTax = @totalTaxOutput output;
print @totalTaxOutput

execute sp_helptext usp_getTotalTaxByCompany






