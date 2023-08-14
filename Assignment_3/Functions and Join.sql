drop database ExerciseDb

create database ExerciseDb
use ExerciseDb

create table CompanyInfo
(CId int primary key identity,
CName nvarchar(50) not null unique)

insert into CompanyInfo values 
('Samsung'), ('HP'), ('Apple'), ('Dell'), ('Toshiba'), ('Redmi')

select * from CompanyInfo order by CId

create table ProductInfo
(PId int primary key identity(101, 1),
PName nvarchar(50) not null,
PPrice float not null,
PMDate date,
CId int foreign key references CompanyInfo)

drop table ProductInfo

insert into ProductInfo values
('Laptop' , 55000.90, '12/12/2023', 1),
('Laptop' , 35000.90, '12/12/2012', 2),
('Mobile' , 15000.90, '12/03/2012', 2),
('Laptop' , 135000.90, '12/12/2012', 3),
('Mobile' , 65000.90, '12/12/2012', 3),
('Laptop' , 35000.90, '12/12/2012', 5),
('Mobile' , 35000.90, '12/12/2012', 5),
('Earpod' , 1000.90, '12/12/2022', 3),
('Laptop' , 85000.90, '12/12/2021', 6),
('Mobile' , 55000.70, '12/12/2020', 1)

select * from ProductInfo order by PId

select c.CId, c.CName, p.PId, p.PName, p.PPrice, p.PMDate from CompanyInfo c join ProductInfo p on c.CId = p.CId

select PName, CName from ProductInfo p join CompanyInfo c on c.CId = p.CId order by CName

select PName, CName from ProductInfo p cross join CompanyInfo

----------------------Part 2------------------------

create table Products
(PId int primary key identity,
PQ int not null,
PPrice float not null,
Discount float not null)

insert into Products values (5, '25000.50', '50'),
(7, '30000.60', '40'),
(10, '50000.50', '60')

select * from Products

create function CalculateDiscount
(
@price float,
@discountPercentage float
)
returns float
as
begin
declare @discountedValue float
set @discountedValue = @price - (@price * (@discountPercentage / 100.0))
return @discountedValue
end

select PId, PPrice Price, Discount, dbo.CalculateDiscount(PPrice, Discount) as 'Price after Discount' from Products
