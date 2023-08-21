create database LibraryDB
use LibraryDB

create table Books
(BookId int primary key,
Title nvarchar(50) not null,
Author nvarchar(50) not null,
Genre nvarchar(50) not null,
Quantity int)

insert into Books values
(1, 'Harry Potter and the Sorcerers Stone', 'J.K. Rowling', 'Fiction', 10),
(2, '1984', 'George Orwell', 'Science Fiction', 12),
(3, 'Murder on the Orient Express', 'Agatha Christie', 'Mystery', 15)

select * from Books
