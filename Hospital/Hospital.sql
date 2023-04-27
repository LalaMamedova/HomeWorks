create database Hospital
use Hospital
create table  [Departments](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Building] int not null check(Building > 0 and Building < 5),
    [Floor] int null default 0 check (Floor>0),
    [Financing] money not null check(Financing>0) default 0,
)

create table Diseases(
     [Id] int identity  primary key,
     [Name] nvarchar(100) not null unique,
     [Severity] int not null check (Severity>0) default 1,
)


create table Doctors(
     [Id] int identity  primary key,
     [Phone] char(10) null,
     [Premium] money not null check (Premium>0) default 0,
     [Salary] money not null check (Salary > 0),
     [Name] nvarchar(100) not null check(Name not like ' ') ,
     [Surname] nvarchar(max) check(Surname not like ' ') not null,
)

create table Examinations(
    [Id] int identity  primary key,
    [DayOfWeek] int not null check (DayOfWeek between 1 and 7),
    [StartTime] time not null check (StartTime between '08:00' and '18:00'),
    [EndTime] time not null check(EndTime > '18:00'),
    [Name] nvarchar(100) not null check(Name not like ' ') unique,
)
create table Ward(
     [Id] int identity primary key,
     [Building] int not null check(Building between 1 and 5) ,
     [Floor] int null check (Floor>0),
     [Name] nvarchar(100) not null check(Name not like ' ') unique,
)


insert into Ward (Building, Floor, Name) values (2,1,N'First')
insert into Ward (Building, Floor, Name) values (3,2,N'Second')
select * from Ward

insert into Diseases(name, severity) values (N'PTSR',2)
select [name] as "Name Of Diseases", Severity as "Severity of Disease" from Diseases


select Building as [Здание] from Ward
select Name as [Название] from Ward
select Id as [Идедкс] from Ward

insert into Departments(name, building, floor, financing) values (N'First depart',4,4,2500)
insert into Departments(name, building, floor, financing) values (N'Second depart',3,4,1200)
insert into Departments(name, building, floor, financing) values (N'Third depart',2,1,13200)
insert into Departments(name, building, floor, financing) values (N'Fourth depart',3,1,14200)

select Name from  Departments where Financing < 3000

select name from Departments where Financing between 12000 and 15000 and Building = 3

insert into Ward(building, floor, name) values (4,1, N'25')
select name from Ward where Building between 4 and 5

select name,Building,Financing from Departments where Financing between 11000 and 25000 and Building between 3 and 6


insert into Doctors(phone, premium, salary, name, surname) values ('+123421',100,1300,N'Sergey',N'Botkin');
insert into Doctors(phone, premium, salary, name, surname) values ('+123421',50,1450,N'Ibn',N'Cina');
insert into Doctors(phone, premium, salary, name, surname) values (N'+88055535', 156,2456,N'Nikolay',N'Amosov')
insert into Doctors(phone, premium, salary, name, surname) values (N'+1234890', 250,4256,N'Nikolay',N'Anikovich')


select Surname from Doctors where Premium + Salary <= 1500;
select Surname from Doctors where Salary/2 > Premium*3

insert into Examinations(dayofweek, starttime, endtime, name) values (4,'12:00','19:00',N'First Exp')
insert into Examinations(dayofweek, starttime, endtime, name) values (5,'13:00','18:20',N'Second Exp')
insert into Examinations(dayofweek, starttime, endtime, name) values (1,'9:00','18:20',N'Third')
insert into Examinations(dayofweek, starttime, endtime, name) values (2,'14:00','18:50',N'Fourht')
insert into Examinations(dayofweek, starttime, endtime, name) values (3,'12:00','18:40',N'Fifth')

select distinct name from Examinations where DayOfWeek between 1 and 3 and StartTime>= '12:00' and StartTime <'15:00'

select [Name], [Building] from Departments where Building =1 or Building = 3 or Building= 8 or Building = 10

insert into  Diseases(name, severity) values (N'Adenovirus', 4)
insert into  Diseases(name, severity) values (N'Chlamydia', 3)
insert into  Diseases(name, severity) values (N'Cholera', 2)
insert into  Diseases(name, severity) values (N'Diphtheria', 1)

select name from Diseases where Severity > 2

insert into Departments(name, building, floor, financing) values (N'Seventh',2,2,15035)
insert into Departments(name, building, floor, financing) values (N'Eighth',4,5,21035)
select [name] from Departments where Building != 1 or Building!=3


select Surname from Doctors where Name like 'N%'