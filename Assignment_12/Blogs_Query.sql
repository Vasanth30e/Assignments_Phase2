create database Blogging
use Blogging

create table Posts
(Id int primary key identity,
Title nvarchar(50) not null,
Content nvarchar(100) not null,
Author nvarchar(50) not null)

create table Comments
(Id int foreign key references Posts,
Content nvarchar(100) not null,
PublicationDate date not null,
PostId int primary key)

select * from Posts
select * from Comments