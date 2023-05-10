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
