create database [Hospital2]
use Hospital2

create table  [Departments](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Building] int not null check(Building > 0 and Building < 5),
)

create table Doctors(
     [Id] int identity  primary key,
     [Phone] char(10) null,
     [Premium] money not null check (Premium>0) default 0,
     [Salary] money not null check (Salary > 0),
     [Name] nvarchar(100) not null check(Name not like ' ') ,
     [Surname] nvarchar(max) check(Surname not like ' ') not null,
     [DepartmentsId]  int foreign key references Departments(Id)
)

create table Examinations(
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null check(Name not like ' ') unique,
)

create table Ward(
     [Id] int identity primary key,
     [Places] int check (Places>0),
     [Name] nvarchar(100) not null check(Name not like ' ') unique,
     [DepartmentId] int not null foreign key references Departments(Id),
)

create table DoctorsExaminations(
      [Id] int identity  primary key,
      [StartTime] time not null check (StartTime between '08:00' and '18:00'),
      [EndTime] time not null,
      [DoctorId] int not null foreign key references Doctors(Id),
      [ExaminationId] int not null foreign key references Examinations(Id),
      [WardId] int not null foreign key references Ward(Id),
      constraint CHK_Time check([EndTime] > [StartTime])
)

INSERT INTO Departments(building, Name) VALUES (1, N'терапии')
INSERT INTO Departments(building, Name) VALUES (2, N'неврологии')
INSERT INTO Departments(building, Name) VALUES (3, N'кардиологии')
INSERT INTO Departments(building, Name) VALUES (4, N'гастроэнтерологии')
INSERT INTO Departments(building, Name) VALUES (4, N'гинекологии')

INSERT INTO Ward([Name], Places, DepartmentId)VALUES (N'Общая', 15, 13)
INSERT INTO Ward([Name], Places, DepartmentId)VALUES (N'Эконом', 12, 14)
INSERT INTO Ward([Name], Places, DepartmentId)VALUES (N'Стандарт', 10, 15)
INSERT INTO Ward([Name], Places, DepartmentId)VALUES (N'Люкс', 5, 18)
INSERT INTO Ward([Name], Places, DepartmentId)VALUES (N'Суперлюкс', 3, 17)


insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+21455564',365,2546,N'Helena',N'Williams',2)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+35414121',165,3046,N'Herta',N'Jostar',1)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+772455564',417,8246,N'Jean',N'Smith ',1)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+772455564',417,8246,N'Wade',N'Thomas  ',1)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+772455564',417,8246,N'Dan',N'Taylor  ',1)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+772455564',417,8246,N'Riley',N'Brown  ',3)
insert into Doctors(phone, premium, salary, name, surname, departmentsid) values (N'+763135212',684,8246,N'Gilbert',N'Black  ',1)


insert into Ward(places, name, departmentid) values (15,'First', 1)
insert into Ward(places, name, departmentid) values (8,'Second', 4)
insert into Ward(places, name, departmentid) values (12,'Third', 3)

--1
select Places from Ward where Places>10

--2
select Departments.Building,Ward.Places from Departments
join Ward on Departments.Id = Ward.DepartmentId

--3
select Departments.Name ,Ward.Places from Departments
join Ward on Departments.Id = Ward.DepartmentId

--4
select Departments.Name, Doctors.Salary+ Doctors.Premium as [Суммарная надбавка] from Departments
join Ward on Departments.Id = Ward.DepartmentId
join DoctorsExaminations on Ward.Id = DoctorsExaminations.WardId
join Doctors on DoctorsExaminations.DoctorId = Doctors.Id

--5
select top 1 Departments.Name, count(*) as DCount from Departments
join Doctors on Doctors.DepartmentsId = Departments.Id
group by Departments.Name
order by DCount desc

--6
select sum(Doctors.Salary + Doctors.Premium), count(*) as [Count] from Doctors

--7
select AVG(Premium + Salary)  as [Avg Salary] from Doctors

--8
select Name from Ward WHERE Places = (SELECT MIN(Places) FROM Ward)

--9
select Departments.Name from Departments
join Ward on Departments.Id = Ward.DepartmentId
where Departments.Building = 1 or Departments.Building = 2
or Departments.Building = 3 or Departments.Building = 4 and
Ward.Places > 10 and Ward.Places = (select sum(Places) from Ward)
group by Departments.Name