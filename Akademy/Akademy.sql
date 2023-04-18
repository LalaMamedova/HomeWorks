use AKademy

CREATE  TABLE  Groups
(
    ID int not NULL primary key identity (1, 1),
    Name nvarchar(10) not null unique ,
    Rating int not null, check (Rating>= 0 AND Rating <=5),
    Year int not null  check(Year>= 0 AND Year <=5),
);

CREATE  TABLE  Departments
(
    ID int not NULL primary key identity (1, 1),
    Financing money not null check (Financing> 0) default 0,
    Name nvarchar(100) not null unique ,
    Rating int not null, check (Rating>= 0 AND Rating <=5),
    Year int not null  check(Year>= 0 AND Year <=5),
);

CREATE  TABLE  Faculties
(
    ID int not NULL primary key identity (1, 1),
    Name nvarchar(100) not null unique,
);


CREATE  TABLE  Teachers
(
    ID int not NULL primary key identity (1, 1),
    EmploymentDate date not null check (EmploymentDate >= '1990-01-01') ,
    Name nvarchar(max) not null,
    Premium money not null check (Premium> 0) default 0,
    Salary money not null check (Salary >= 0),
    Surname nvarchar(max) not null,
);