create database OurExerciseDb on primary
(Name = 'OurExercise_Db', Filename = 'D:\Training\Database Connectivity & Web Services\Assignments\Assignment_1\OurExercise_Db.mdf',
size = 12mb,maxsize = 24mb, filegrowth = 4mb)
log on
(Name = 'OurExercise_log', Filename = 'D:\Training\Database Connectivity & Web Services\Assignments\Assignment_1\OurExercise_Db.ldf')

collate SQL_Latin1_General_CP1_CI_AS

use OurExerciseDb

create table StudentRegistrations
(StudentId int,
StudentName nvarchar(50) not null,
CourseCode nvarchar(50),
RegistrationDate date not null
constraint pk_registration primary key (StudentId, CourseCode) )

select * from StudentRegistrations

insert into StudentRegistrations values (001, 'Ram', '121', '10/08/2023')
insert into StudentRegistrations values (002, 'Sam', '121', '10/08/2023')
insert into StudentRegistrations values (003, 'Arun', '122', '08/08/2023'),
(004, 'Varun', '122', '07/08/2023')
insert into StudentRegistrations values (005, 'Jai', '123', '07/08/2023')
insert into StudentRegistrations values (005, 'Kumar', '123', '07/08/2023') --it will show error because the combination of StudentId and CourseCode can't be repeated more than one time

