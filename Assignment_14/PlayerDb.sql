create database PlayersDb
use PlayersDb

create table Player
(PlayerId int primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
JerseyNumber int not null,
Position nvarchar(50) not null,
Team nvarchar(50) not null)

insert into Player values (1, 'Dhoni', 'MS', 11, 'Keeper', 'CSK')