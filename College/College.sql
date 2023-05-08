create database College
use College

create table  Teacher(
     [Id] int identity  primary key,
     [Name] nvarchar(100) not null check (len(name)>1),
     [Surname] nvarchar(100) not null check (len(Surname)>1),
)

create table  [Assistants](
    [Id] int identity  primary key,
    [TeacherId] int not null foreign key references Teacher(Id)
)

create table Curators(
    [Id] int identity primary key,
    [TeacherId]  int not null foreign key references Teacher(Id)
)

create table Deans(
    [Id] int identity primary key,
    [TeacherId] int not null foreign key references Teacher(Id)
)

create table  [Faculties](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Building] int not null check(Building > 0 and Building < 5),
    [DeanId] int not null foreign key references Deans(Id)
)

create table Heads(
     [Id] int identity  primary key,
     [TeacherId]  int  not null foreign key references Teacher(Id),
)

create table  [Departments](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [FacultyId] int not null foreign key references Faculties(Id),
    [HeadsId]  int not null foreign key references Heads(Id),
    [Building] int not null check(Building > 0 and Building < 5),
)

-- drop  table [GroupsCurators]
-- drop  table [GroupsLectures]
-- drop  table [Group]
-- drop table  Departments

create table [Group](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Year] int not null  check(Year>= 0 AND Year <=5),
    [DepartmentsId]  int not null foreign key references Departments(Id),
    [FacultyId]  int not null foreign key references Faculties(Id),
)


create table GroupsCurators(
    [Id] int identity  primary key,
    [GroupId]  int not null foreign key references [Group](Id),
    [CuratorId]  int not null foreign key references Curators(Id),
)


create table Subjects(
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
)

create table Lectures(
    [Id] int identity  primary key,
    [SubjectId] int  not null foreign key references Subjects(Id),
    [TeacherId]  int  not null foreign key references Teacher(Id),
)

create table LectureRooms(
    [Id] int identity  primary key,
    [Building] int not null check(Building > 0 and Building < 5),
    [Name] nvarchar(100) not null unique,
)


create table GroupsLectures(
    [Id] int identity  primary key,
    [GroupId]  int  not null foreign key references [Group](Id),
    [LectureId]  int  not null foreign key references Lectures(Id),
)

create table [Schedules](
    [Id] int identity  primary key,
    [Class] int not null check(Class between 1 and 6),
    [DayOfWeek] int not null check(DayOfWeek between 1 and 7),
    [Week] int null check(Week between 1 and 52),
    [LectureId]  int  not null foreign key references Lectures(Id),
    [LectureRoomId]  int  not null foreign key references LectureRooms(Id),
);

insert into Teacher(name, surname) values (N'Cassandra', N'Bowman')
insert into Teacher(name, surname) values (N'Edward', N'Hopper”')
insert into Teacher(name, surname) values (N'Faye ', N'King')
insert into Teacher(name, surname) values (N'Neal ', N'Feron')
insert into Teacher(name, surname) values (N'Alex ', N'Carmack')
insert into Teacher(name, surname) values (N'Melanie  ', N'Curtis')
insert into Teacher(name, surname) values (N'Angel', N'Grimes')
insert into Teacher(name, surname) values (N'Lewis', N'Shaw')



insert into Assistants(TeacherId) values (1)
insert into Assistants(TeacherId) values (2)
insert into Assistants(TeacherId) values (3)
insert into Assistants(TeacherId) values (7)
insert into Assistants(TeacherId) values (8)

insert into Curators(TeacherId) values (1)
insert into Curators(TeacherId) values (4)
insert into Curators(TeacherId) values (2)
insert into Curators(TeacherId) values (5)

insert into Deans(TeacherId) values (2)
insert into Deans(TeacherId) values (3)
insert into Deans(TeacherId) values (5)

insert into Faculties(name, building, deanid) values (N'Computer Science',2,2)
insert into Faculties(name, building, deanid) values (N'Software Development',1,3)
insert into Faculties(name, building, deanid) values (N'Engineering',2,3)

insert into Heads(TeacherId) values (1)
insert into Heads(TeacherId) values (4)
insert into Heads(TeacherId) values (5)

insert into Departments(name, facultyid, headsid, Building) values ('First',1,2,3)
insert into Departments(name, facultyid, headsid,Building) values ('Secnd',2,1,2)
insert into Departments(name, facultyid, headsid,Building) values ('Third',3,3,3)

insert into [Group](name, year, departmentsid, FacultyId) values (N'F505',2,2,1)
insert into [Group](name, year, departmentsid,FacultyId) values (N'A311',4,3,2)
insert into [Group](name, year, departmentsid,FacultyId) values (N'A104',1,1,2)
insert into [Group](name, year, departmentsid,FacultyId) values (N'T412',5,3,1)

insert into GroupsCurators(GroupId, curatorid) values (2,1)
insert into GroupsCurators(GroupId, curatorid) values (1,4)
insert into GroupsCurators(GroupId, curatorid) values (1,6)
insert into GroupsCurators(GroupId, curatorid) values (3,7)

insert into Subjects(Name) values (N'Python')
insert into Subjects(Name) values (N'IT')
insert into Subjects(Name) values (N'C#')
insert into Subjects(Name) values (N'SQL')

insert into Lectures(subjectid, teacherid) values (2,3)
insert into Lectures(subjectid, teacherid) values (1,4)
insert into Lectures(subjectid, teacherid) values (3,2)
insert into Lectures(subjectid, teacherid) values (1,2)
insert into Lectures(subjectid, teacherid) values (4,2)
insert into Lectures(subjectid, teacherid) values (3,5)
insert into Lectures(subjectid, teacherid) values (2,5)
insert into Lectures(subjectid, teacherid) values (2,7)


insert into LectureRooms(building, name) values (1,N'A3145')
insert into LectureRooms(building, name) values (3,N'B2351')
insert into LectureRooms(building, name) values (2,N'F2141')
insert into LectureRooms(building, name) values (4,N'A311')
insert into LectureRooms(building, name) values (4,N'A104')

insert into GroupsLectures(groupid, lectureid) values (2,2)
insert into GroupsLectures(groupid, lectureid) values (3,3)
insert into GroupsLectures(groupid, lectureid) values (4,3)
insert into GroupsLectures(groupid, lectureid) values (4,5)
insert into GroupsLectures(groupid, lectureid) values (5,5)
insert into GroupsLectures(groupid, lectureid) values (2,4)


insert into Schedules(class, dayofweek, week, lectureid, lectureroomid) values (1,3,4,2,1)
insert into Schedules(class, dayofweek, week, lectureid, lectureroomid) values (2,5,3,3,2)
insert into Schedules(class, dayofweek, week, lectureid, lectureroomid) values (2,2,5,9,3)
insert into Schedules(class, dayofweek, week, lectureid, lectureroomid) values (3,4,6,3,2)
insert into Schedules(class, dayofweek, week, lectureid, lectureroomid) values (4,2,2,4,2)


--1 - Вывести названия аудиторий, в которых читает лекции преподаватель “Edward Hopper
select LectureRooms.Name from Schedules
join LectureRooms on LectureRooms.Id = Schedules.LectureRoomId
join Lectures on Lectures.Id = Schedules.LectureId
join Teacher on Teacher.Id = Lectures.TeacherId
where Teacher.Name = 'Edward' and Teacher.Surname = 'Hopper'


--2?? - Вывести фамилии ассистентов, читающих лекции в группе “F505”.
select Surname from Teacher
join Assistants on Teacher.Id = Assistants.TeacherId
join Lectures on Lectures.TeacherId = Assistants.TeacherId
join GroupsLectures on GroupsLectures.LectureId = Lectures.Id
join [Group] on GroupsLectures.GroupId = [Group].Id
where [Group].Name = 'F505'

--3 - Вывести дисциплины, которые читает преподаватель “Alex Carmack” для групп 5-го курса.
select Subjects.Name from Lectures
join Teacher  on Teacher.Id = Lectures.TeacherId
join Subjects on Subjects.Id = Lectures.SubjectId
join GroupsLectures  on Lectures.Id = GroupsLectures.LectureId
join [Group] on [Group].Id = GroupsLectures.GroupId
where Teacher.Name = 'Alex' and Teacher.Surname = 'Carmack' and [Group].Year = 5

--4 -Вывести фамилии преподавателей, которые не читают лекции по понедельникам.
SELECT Surname FROM Teacher
JOIN [Group] G on Teacher.Name = G.Name
JOIN GroupsLectures GL on G.Id = GL.GroupId
JOIN Schedules S on GL.LectureId = S.LectureId
WHERE S.DayOfWeek != 1

--5 - Вывести названия аудиторий, с указанием их корпусов, в которых нет лекций в среду второй недели на третьей паре.
select distinct LectureRooms.Name from Schedules
join LectureRooms on LectureRooms.Id = Schedules.LectureRoomId
join Lectures on Lectures.Id = Schedules.LectureId
join Teacher on Teacher.Id = Lectures.TeacherId
where Schedules.DayOfWeek !=3 and Schedules.Week !=2 and Schedules.Class != 3

--6 - Вывести полные имена преподавателей факультета “Computer Science”, которые не курируют группы кафедры “Software Development”.
SELECT Teacher.Name, Surname, Faculties.Name FROM Teacher
JOIN Curators  on Teacher.Id = Curators.TeacherId
JOIN Deans  on Teacher.Id = Deans.TeacherId
JOIN Faculties on Deans.Id = Faculties.DeanId
join [Group]  on Faculties.Id = [Group].FacultyId
where Faculties.Name != 'Computer Science'



--7. Вывести список номеров всех корпусов, которые имеются в таблицах факультетов, кафедр и аудиторий.
select Faculties.Building from Faculties
join LectureRooms on Faculties.Building  = LectureRooms.Building
join Departments on Faculties.Building = Departments.Building

--8 - Вывести полные имена преподавателей в следующем порядке: деканы факультетов, заведующие кафедрами, преподаватели, кураторы, ассистенты.
select Surname,name from Teacher
join Deans  on Teacher.Id = Deans.TeacherId
union all
select Surname,name from Teacher
join Heads  on Teacher.Id = Heads.TeacherId
union all
select Surname,name from Teacher
union all
select Surname,name from Teacher
join Curators  on Teacher.Id = Curators.TeacherId
union all
select Surname,name from Teacher
join Assistants  on Teacher.Id = Assistants.TeacherId


--9 - Вывести дни недели (без повторений), в которые имеются занятия в аудиториях “A311” и “A104” корпуса 6.
select DayOfWeek from Schedules
join LectureRooms on LectureRooms.Id = Schedules.LectureRoomId
join Lectures  on Lectures.Id = Schedules.LectureId
where LectureRooms.Building = 4 and LectureRooms.Name = 'A3145' or LectureRooms.Name = 'B2351'