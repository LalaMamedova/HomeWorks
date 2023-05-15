create database HW10
use HW10

create table  [Departments](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Building] int not null check(Building > 0 and Building < 5),
    [Financing] money not null check(Financing>0) default 0,
)

create table Diseases(
     [Id] int identity  primary key,
     [Name] nvarchar(100) not null unique,
)

create table Ward(
     [Id] int identity primary key,
     [Name] nvarchar(100) not null unique,
     [Places] int not null check(Places>0) ,
     [DepartarmentID] int foreign key references Departments(Id),
)


create table Doctors(
     [Id] int identity  primary key,
     [Salary] money not null check (Salary > 0),
     [Name] nvarchar(100) not null check(Name not like ' ') ,
     [Surname] nvarchar(max) check(Surname not like ' ') not null,
)

create table Examinations(
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null check(Name not like ' ') unique,
)
create TABLE DoctorExaminations(
    [Id] int identity  primary key,
    [Date] date not null,
    [DiseasesId] int foreign key references Diseases(Id),
    [DoctorsId] int foreign key references Doctors(Id),
    [ExaminationsId] int foreign key references Examinations(Id),
    [WardId] int foreign key references Ward(Id),

)

create table Professors(
    [Id] int identity primary key,
    [DoctorsId] int foreign key references Doctors(Id),
)

create table Interns(
    [Id] int identity primary key,
    [DoctorsId] int foreign key references Doctors(Id),
)

insert into Departments(name, building, financing) values (N'Urology',4,20000)
insert into Departments(name, building, financing) values (N'Cardiology',3,5200)
insert into Departments(name, building, financing) values (N'Surgery',1,113200)
insert into Departments(name, building, financing) values (N'Theraphy',2,34200)
insert into Departments(name, building, financing) values (N'Neurology',3,112200)
insert into Departments(name, building, financing) values (N'Anesthesiology',3,145200)
insert into Departments(name, building, financing) values (N'Gastroenterology',4,120200)
insert into Departments(name, building, financing) values (N'Hematology',2,10200)

insert into Ward (name, places, departarmentid) values (N'First',24,3)
insert into Ward (name, places, departarmentid) values (N'Second',34,5)
insert into Ward (name, places, departarmentid) values (N'Third',42,3)
insert into Ward (name, places, departarmentid) values (N'Foruth',30,2)
insert into Ward (name, places, departarmentid) values (N'Fifth',40,4)
insert into Ward (name, places, departarmentid) values (N'Sixth',15,1)

insert into Diseases(Name) values (N'Cancer')
insert into Diseases(Name) values (N'Polio')
insert into Diseases(Name) values (N'Malaria')
insert into Diseases(Name) values (N'Tuberculosis')
insert into Diseases(Name) values (N'Meningitis')
insert into Diseases(Name) values (N'Hepatitis B')
insert into Diseases(Name) values (N'Zika virus')

insert into Doctors(salary, name, surname) values (1300,N'Sergey',N'Botkin');
insert into Doctors(salary, name, surname) values (1450,N'Ibn',N'Cina');
insert into Doctors(salary, name, surname) values (2456,N'Nikolay',N'Amosov')
insert into Doctors(salary, name, surname) values (4256,N'Nikita',N'Anikovich')
insert into Doctors(salary, name, surname) values (2556,N'Anantha',N'Roman')
insert into Doctors(salary, name, surname) values (3556,N'Jean',N'Ejov')

insert into Examinations(Name) values(N'CAT')
insert into Examinations(Name) values(N'GATE')
insert into Examinations(Name) values(N'GRE')
insert into Examinations(Name) values(N'FTII JET')
insert into Examinations(Name) values(N'NMAT')

insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values ('1/10/2023',3,3,1,5)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values ('10/12/2021',1,1,5,3)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values ('04/14/2022',4,5,2,1)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values ('2/26/2023',4,2,3,4)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values ('5/30/2022',2,5,4,1)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values (dateadd(week,-1,getdate()),3,2,4,1)
insert into DoctorExaminations(date, diseasesid, doctorsid, examinationsid, wardid) values (dateadd(week,-1,getdate()),5,2,4,5)

insert into Interns(DoctorsId) values (1)
insert into Interns(DoctorsId) values (4)
insert into Interns(DoctorsId) values (5)
insert into Interns(DoctorsId) values (2)


--1

select Ward.Name, Places from Ward
join Departments  on Departments.Id = Ward.DepartarmentID
WHERE  Places >= 5
AND EXISTS (SELECT * FROM Ward WHERE building = 4 AND Places >= 15)


--2
select Examinations.Name, Date from Examinations
join DoctorExaminations on Examinations.Id = DoctorExaminations.ExaminationsId
where YEAR(DoctorExaminations.Date) = YEAR(dateadd(week,-1,getdate()))


--3
select Name from Diseases
left join DoctorExaminations on Diseases.Id = DoctorExaminations.DiseasesId
where DoctorExaminations.DiseasesId is null

--4
select Name,Surname from Doctors
left join DoctorExaminations on Doctors.Id = DoctorExaminations.DoctorsId
where DoctorExaminations.DoctorsId is null

--5
select Departments.Name from Departments
join Ward on Departments.Id = Ward.DepartarmentID
left join DoctorExaminations on Ward.Id = DoctorExaminations.WardId
where DoctorExaminations.WardId is null
