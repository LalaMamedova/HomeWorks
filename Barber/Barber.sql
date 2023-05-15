create database BarberBase
use BarberBase


create table Customer(
    [Id] int primary key identity(1,1) ,
    [Name] varchar(100) not null,
    [Surname] varchar(100) not null,
    [Patronymic] varchar(100) not null,
    [Phone] varchar(10) not null,
    [Email] varchar(269) not null unique,
)

create table Pozition(
    [Id] int primary key identity,
    [Name] varchar(100) not null,
)

create table Rating(
    [Id] int primary key identity,
    [CustomerRating] varchar(100) not null,
)


create table Barber(
    [Id] int primary key identity(1,1) ,
    [Name] varchar(100) not null,
    [Surname] varchar(100) not null,
    [Patronymic] varchar(100) not null,
    [Gender] bit not null,
    [Phone] varchar(10) not null,
    [Email] varchar(269) not null unique,
    [Birthday] date not null,
    [EmploymentDate] date not null,
    [PozitionId] int foreign key references Pozition(Id),

)

create table Service(
    [Id] int identity(1,1),
    [ServiceName] varchar(100) not null,
    [ServicePrice] smallmoney not null,
    [BarberId] int foreign key references Barber(Id),
)



create table FeadBack(
    [Id] int identity,
    [CustomerId] int foreign key references Customer(Id),
    [BarberId] int foreign key references Barber(Id),
    [RatingId] int foreign key references Rating(Id),
)
