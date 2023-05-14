create database University
use University

create table Curators(
    [Id] int identity primary key,
    [Name] nvarchar(max) not null,
    [Surname] nvarchar(max) not null,
)

create table  [Faculties](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
)

create table  [Departments](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [FacultyId] int not null foreign key references Faculties(Id),
    [Building] int not null check(Building > 0 and Building < 5),
    [Financing] int not null check(Financing >0 ) default 0,

)
create table [Group](
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null unique,
    [Year] int not null  check(Year>= 0 AND Year <=5),
    [DepartmentsId]  int not null foreign key references Departments(Id),
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

create table  Teacher(
     [Id] int identity  primary key,
     [IsProfessor] bit not null default 0,
     [Salary] smallmoney not null  check (Salary > 0),
     [Name] nvarchar(100) not null check (len(name)>1),
     [Surname] nvarchar(100) not null check (len(Surname)>1),
)

create table Lectures(
    [Id] int identity  primary key,
    [Date] date not null check (date <=getdate()),
    [SubjectId] int  not null foreign key references Subjects(Id),
    [TeacherId]  int  not null foreign key references Teacher(Id),
)

create table GroupsLectures(
    [Id] int identity  primary key,
    [GroupId]  int  not null foreign key references [Group](Id),
    [LectureId]  int  not null foreign key references Lectures(Id),
)

create table  Students(
    [Id] int identity  primary key,
    [Name] nvarchar(100) not null check (len(name)>1),
    [Surname] nvarchar(100) not null check (len(Surname)>1),
    [Rating] int not null check(Rating between 0 and 4),
)


create table GroupsStudents(
    [Id] int identity  primary key,
    [GroupId]  int  not null foreign key references [Group](Id),
    [StudentId]  int  not null foreign key references [Students](Id),
)


insert into Curators(name, surname) values (N'Ann',N'Adams')
insert into Curators(name, surname) values (N'Joanna',N'Austin')
insert into Curators(name, surname) values (N'Jacqueline ',N'Baker')
insert into Curators(name, surname) values (N'Claire',N'Barber')
insert into Curators(name, surname) values (N'Marvin',N'Barker')

insert into Faculties(Name) values (N'Computer Science')
insert into Faculties(Name) values (N'Engineering')
insert into Faculties(Name) values (N'Cybersecurity')
insert into Faculties(Name) values (N'Surgery')

insert into Departments(name, facultyid, building, financing) values (N'Software  Development',1,3,11000)
insert into Departments(name, facultyid, building, financing) values (N'Hardware  Development',2,1,16000)
insert into Departments(name, facultyid, building, financing) values (N'Digital economy and mass communications',3,4,10000)
insert into Departments(name, facultyid, building, financing) values (N'Plastic Surgery',4,2,26000)
insert into Departments(name, facultyid, building, financing) values (N'IT Development',3,1,35000)


insert into [Group](name, year, departmentsid) values ('D221',2,1)
insert into [Group](name, year, departmentsid) values ('A122',3,2)
insert into [Group](name, year, departmentsid) values ('J2594',4,3)
insert into [Group](name, year, departmentsid) values ('C521',3,4)
insert into [Group](name, year, departmentsid) values ('C921',1,4)
insert into [Group](name, year, departmentsid) values ('C522',2,4)
insert into [Group](name, year, departmentsid) values ('E5234',4,1)
insert into [Group](name, year, departmentsid) values ('U421',4,2)
insert into [Group](name, year, departmentsid) values ('N821',1,1)

insert into GroupsCurators(GroupId, curatorid) values (1,1)
insert into GroupsCurators(GroupId, curatorid) values (1,2)
insert into GroupsCurators(GroupId, curatorid) values (2,2)
insert into GroupsCurators(GroupId, curatorid) values (2,1)
insert into GroupsCurators(GroupId, curatorid) values (3,1)
insert into GroupsCurators(GroupId, curatorid) values (4,4)
insert into GroupsCurators(GroupId, curatorid) values (2,4)
insert into GroupsCurators(GroupId, curatorid) values (3,4)

insert into Subjects(Name) values (N'Python')
insert into Subjects(Name) values (N'IT')
insert into Subjects(Name) values (N'C#')
insert into Subjects(Name) values (N'SQL')
insert into Subjects(Name) values (N'Therapy')
insert into Subjects(Name) values (N'Attacks on elements of the "Internet of Things"')

insert into Teacher(isprofessor, salary, name, surname) values (0, 2500,N'Beatrice', N'Garraway')
insert into Teacher(isprofessor, salary, name, surname) values (1, 1500,N'Kelsey ', N'Foster')
insert into Teacher(isprofessor, salary, name, surname) values (0, 5500,N'Ruby ', N'Webster')
insert into Teacher(isprofessor, salary, name, surname) values (1, 5500,N'Jerry ', N'Hum')
insert into Teacher(isprofessor, salary, name, surname) values (1, 3300,N'Tommy  ', N'Ferguson')
insert into Teacher(isprofessor, salary, name, surname) values (0, 3200,N'Melanie  ', N'Curtis')
insert into Teacher(isprofessor, salary, name, surname) values (0, 10000,N'Angel', N'Grimes')
insert into Teacher(isprofessor, salary, name, surname) values (0, 2000,N'Lewis', N'Shaw')

insert into Lectures(date, subjectid, teacherid) values ('2022-05-01', 2,2)
insert into Lectures(date, subjectid, teacherid) values ('2023-05-05', 2,5)
insert into Lectures(date, subjectid, teacherid) values ('2022-03-07', 3,2)
insert into Lectures(date, subjectid, teacherid) values ('2023-05-04', 2,5)
insert into Lectures(date, subjectid, teacherid) values ('2023-02-04', 4,2)
insert into Lectures(date, subjectid, teacherid) values ('2023-03-04', 6,6)
insert into Lectures(date, subjectid, teacherid) values ('2023-01-04', 5,7)

insert into GroupsLectures(groupid, lectureid) values (1,1)
insert into GroupsLectures(groupid, lectureid) values (2,1)
insert into GroupsLectures(groupid, lectureid) values (3,2)
insert into GroupsLectures(groupid, lectureid) values (4,2)
insert into GroupsLectures(groupid, lectureid) values (1,2)
insert into GroupsLectures(groupid, lectureid) values (9,4)


insert into Students(name, surname, rating) values (N'Dane', N'Meskill',1)
insert into Students(name, surname, rating) values (N'Humbert', N'Bates',2)
insert into Students(name, surname, rating) values (N'Jerry', N'Hall',3)
insert into Students(name, surname, rating) values (N'Vanessa', N'Presley',1)
insert into Students(name, surname, rating) values (N'Gerry', N'Fleming',3)
insert into Students(name, surname, rating) values (N'Erasmus', N'Floyd',4)
insert into Students(name, surname, rating) values (N'Carmen', N'Douglas',4)
insert into Students(name, surname, rating) values (N'Hadwin', N'Baldwin',2)
insert into Students(name, surname, rating) values (N'Theo', N'Jensen',3)

insert into GroupsStudents(groupid, studentid) values (1,1)
insert into GroupsStudents(groupid, studentid) values (1,2)
insert into GroupsStudents(groupid, studentid) values (1,3)
insert into GroupsStudents(groupid, studentid) values (3,4)
insert into GroupsStudents(groupid, studentid) values (2,5)
insert into GroupsStudents(groupid, studentid) values (1,7)
insert into GroupsStudents(groupid, studentid) values (2,6)
insert into GroupsStudents(groupid, studentid) values (7,8)
insert into GroupsStudents(groupid, studentid) values (8,4)


--1 - . Вывести номера корпусов, если суммарный фонд финансирования расположенных в них кафедр превышает 100000.
select Building,Name from Departments
where Financing > 10000

-- 2 -Вывести названия групп 4-го курса кафедры “Software  Development”, которые имеют более 10 пар в первую неделю.
select [Group].Name as [Group name] from [Group]
join Departments on Departments.Id = [Group].DepartmentsId
join GroupsLectures on [Group].Id = GroupsLectures.GroupId
where Departments.Name = 'Software  Development' and [Group].Year = 4

--3 - Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) больше, чем рейтинг группы “D221”.
select  [Group].name,Rating from [Group]
join GroupsStudents  on [Group].Id = GroupsStudents.GroupId
join Students on Students.Id = GroupsStudents.StudentId
where (select avg(Rating) from Students where [Group].Name != 'D221' ) > (select avg(Rating) from Students where [Group].Name = 'D221')


-- 4 - Вывести фамилии и имена преподавателей, ставка которых выше средней ставки профессоров.
select Surname,Name,IsProfessor, avg(Salary) from Teacher
where Salary > (select AVG(Salary) from Teacher where IsProfessor = 1 ) and IsProfessor = 0
group by Surname, Name, IsProfessor

-- 5 - Вывести названия групп, у которых больше одного куратора.
select [Group].Name, count(*) as CuratorsCount from [Group]
join GroupsCurators on [Group].id = GroupsCurators.GroupId
join Curators on GroupsCurators.CuratorId = Curators.Id
group by [Group].Name

-- 6 - Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) меньше, чем минимальный  рейтинг групп 4-го курса.
select [Group].Name,Rating from [Group]
join GroupsStudents  on [Group].Id = GroupsStudents.GroupId
join Students on Students.Id = GroupsStudents.StudentId
where (select avg(Rating) from Students) < (select min(Rating) from Students where [Group].Year = 4)


-- 7 - Вывести названия факультетов, суммарный фонд финансирования кафедр которых больше суммарного фонда финансирования кафедр факультета “Computer Science”.
select Faculties.Name from Faculties
join Departments  on Faculties.Id = Departments.FacultyId
where (select sum(Departments.Financing) from Departments) >
(select sum(Departments.Financing) from Departments inner join Faculties on Faculties.Id = Departments.FacultyId where Faculties.Name = 'Computer Science')


-- 8 - Вывести названия дисциплин и полные имена преподавателей, читающих наибольшее количество лекций по ним.
select Teacher.Name + Teacher.Surname, Subjects.Name  as [Full name], count(*) as SubjectCount from Lectures
join Subjects on Subjects.Id = Lectures.SubjectId
join Teacher on Teacher.Id = Lectures.TeacherId
group by Teacher.Name, Teacher.Surname, Subjects.Name


-- 9 - Вывести название дисциплины, по которому читается меньше всего лекций.
select  top 1 Subjects.Name, count(*) as SubjectCount from Lectures
join Subjects on Subjects.Id = Lectures.SubjectId
join Teacher on Teacher.Id = Lectures.TeacherId
group by Subjects.Name


--10 - Вывести количество студентов и читаемых дисциплин на кафедре “Software Development”.
select  count(*) as [Students Count], Subjects.Name as [Subject name] from Students
join GroupsStudents on Students.Id = GroupsStudents.StudentId
join [Group] on [Group].Id = GroupsStudents.GroupId
join GroupsLectures on [Group].Id = GroupsLectures.GroupId
join Lectures on GroupsLectures.LectureId = Lectures.Id
join Subjects on Lectures.SubjectId = Subjects.Id
join Departments  on Departments.Id = [Group].DepartmentsId
where Departments.Name = 'Software  Development'
group by Subjects.Name