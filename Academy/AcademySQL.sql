create database AcademyNumberTwo
use AcademyNumberTwo

create table  [Departments](
    [Id] int identity  primary key,
    [Financing] money not null check(Financing>0) default 0,
    [Name] nvarchar(100) not null unique,
)


create table [Faculties](
    [Id] int identity  primary key,
    [Dean] nvarchar(max) not null,
    [Name] nvarchar(100) not null unique,
)

CREATE  TABLE [Groups]
(
    [ID] int not NULL primary key identity (1, 1),
    [Name] nvarchar(10) not null unique ,
    [Rating] int not null, check (Rating>= 0 AND Rating <=5),
    [Year] int not null  check(Year>= 0 AND Year <=5),
);

CREATE  TABLE  Teachers
(
    [ID] int not NULL primary key identity (1, 1),
    [EmploymentDate] date not null check (EmploymentDate >= '1990-01-01') ,
    [Name] nvarchar(max) not null,
    [Surname] nvarchar(max) not null,
    [IsAssistant] bit default 0,
    [IsProfessor] bit default 0,
    [Position] nvarchar(max) not null ,
    [Premium] money not null check (Premium > 0) default 0,
    [Salary] money not null check (Salary >= 0),
);

insert  into Departments (Financing, Name) values (25500, N'Каведра номер 1');
insert  into Departments (Financing, Name) values (4221, N'Каведра номер 2');
insert  into Departments (Financing, Name) values (25500, N'English Language');

select * from Departments order by  [Name], [Financing] DESC;




insert into Groups (Name, Rating, Year) values (N'Группа 1', 3, 1);
select [Name] as [Grop Name], Rating as [Group Rating] from Groups ;




insert into Teachers(EmploymentDate, Name, Surname, IsAssistant, IsProfessor, Position, Premium, Salary)
values ('5.12.1996', N'Lala', N'Mamedova', 0, 1, N'Инорматика',15,500);

insert into Teachers(EmploymentDate, Name, Surname, IsAssistant, IsProfessor, Position, Premium, Salary)
values ('5.12.1996', N'Laman', N'Aliyeva', 0, 0, N'ИЗО',15,2000);

insert into Teachers(EmploymentDate, Name, Surname, IsAssistant, IsProfessor, Position, Premium, Salary)
values ('8.9.2004', N'Magomed', N'Babayev', 1, 0, N'Технологии',170,1600);

select Surname, Salary, Premium from  Teachers;



insert into Faculties(dean, name) values (N'Директор', N'Факультет');
Select 'The dean of faculty ' +Name+ '  is ' +convert(varchar(10), Dean)  from Faculties order by Dean desc


select Surname  from Teachers where Salary>1500;


delete from Departments where Id=3;
select Name from Departments where Financing > 25000 or Financing < 11000;


insert into Faculties(dean, name) values (N'Директор', N'Computer Science');
select Name from Faculties where Name != 'Computer Science';



select Surname, Position from  Teachers where  IsProfessor = 0;
select Surname, Position, Salary,Premium from Teachers where Premium> 160 and Premium <550;

select Surname, Salary from  Teachers where  IsAssistant = 1;

select Surname, Position from Teachers where EmploymentDate < '01.01.2000';


SELECT [Name] AS [Name of Department] FROM Departments WHERE [Name]< 'Software Development' ORDER BY [Name];


select Surname, Salary + Premium as [Sum] from Teachers where Premium + Salary < 1200;

insert into Groups(name, rating, year) values ('1221',3,5);
select  Name from Groups where Year = 5 and Rating >= 2 and Rating < 4;



select  Surname, Salary from Teachers where  IsAssistant = 1 and Salary < 550 or Premium < 200;