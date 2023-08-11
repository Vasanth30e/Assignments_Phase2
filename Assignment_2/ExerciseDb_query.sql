create database ExerciseDb on primary
(Name = 'Exercise_Db', Filename = 'D:\Training\Database Connectivity & Web Services\Day 2\Exercise_Db.mdf')
log on
(Name = 'Exercise_log', Filename = 'D:\Training\Database Connectivity & Web Services\Day 2\Exercise_log.ldf')

use ExerciseDb

create table Publisher
(PId int primary key,
Publisher nvarchar(50) not null unique )

create table Category
(CId int primary key,
Category nvarchar(50) not null unique )

create table Author
(AId int primary key,
AuthorName nvarchar(50) not null unique )

create table Book
(BId int primary key,
BName nvarchar(50) not null,
BPrice float,
AId int foreign key references Author,
PId int foreign key references Publisher,
CId int foreign key references Category)

insert into Category values (1, 'Fiction'),(2, 'Science Fiction'),(3, 'Mystery')

select * from Category

insert into Publisher values (1, 'Publisher_A'), (2, 'Publisher_B'), (3, 'Publisher_C')

select * from Publisher

insert into Author values (1, 'J.K. Rowling'), (2, 'George Orwell'), (3, 'Agatha Christie')

select * from Author

insert into Book (BId, BName, BPrice, AId, PId, CId) values 
(1, 'Harry Potter and the Sorcerers Stone', 250.50, 1, 1, 1),
(2, '1984', 315.50, 2, 2, 2),
(3, 'Murder on the Orient Express', 260.75, 3, 3, 3),
(4, 'Harry Potter and the Chamber of Secrets', 220.99, 1, 1, 1),
(5, 'Animal Farm', 350.25, 2, 2, 2),
(6, 'The Murder of Roger Ackroyd', 325.99, 3, 3, 3)

select BId, BName, BPrice, AuthorName Author, Publisher, Category from Book b join Author a on b.AId = a.AId join Publisher p on b.PId = p.PId join Category c on b.CId = c.CId