create database BarberBase
use BarberBase


create table Customer(
    [Id] int primary key identity(1,1) ,
    [Name] nvarchar(100) not null,
    [Surname] nvarchar(100) not null,
    [Patronymic] nvarchar(100) not null,
    [Phone] nvarchar(10) not null,
    [Email] nvarchar(269) not null unique,
)

create table Pozition(
    [Id] int primary key identity,
    [Name] nvarchar(100) not null,
)

create table Rating(
    [Id] int primary key identity,
    [CustomerRating] nvarchar(100) not null,
)


create table Barber(
    [Id] int primary key identity(1,1) ,
    [Name] nvarchar(100) not null,
    [Surname] nvarchar(100) not null,
    [Patronymic] nvarchar(100) not null,
    [Gender] bit not null,
    [Phone] nvarchar(10) not null,
    [Email] nvarchar(269) not null unique,
    [Birthday] date not null,
    [EmploymentDate] date not null,
    [PozitionId] int foreign key references Pozition(Id),

)

create table Service(
    [Id] int identity(1,1),
    [ServiceName] nvarchar(100) not null,
    [ServicePrice] smallmoney not null,
    [BarberId] int foreign key references Barber(Id),
)

create table Feedback (
    [Id] int identity,
    [CustomerId] int foreign key references Customer(Id),
    [BarberId] int foreign key references Barber(Id),
    [RatingId] int foreign key references Rating(Id),
)
CREATE TABLE Schedule (
      [id] INT PRIMARY KEY identity ,
      [Date] DATE NOT NULL,
      [Time] TIME NOT NULL,
      [BarberID] INT FOREIGN KEY REFERENCES Barber(id),
      [CustomerID] INT FOREIGN KEY REFERENCES Customer(id)
);

CREATE TABLE ArchiveSchedule (
      [id] INT PRIMARY KEY identity ,
      [Date] DATE NOT NULL,
      [Time] TIME NOT NULL,
      [BarberID] INT FOREIGN KEY REFERENCES Barber(id),
      [CustomerID] INT FOREIGN KEY REFERENCES Customer(id)
);
CREATE TABLE Salon (
    BarberID INT foreign KEY references Barber(ID),
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL unique,
    Address NVARCHAR(200) NOT NULL
);

INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Иван', N'Иванов', N'Иванович', '1234567890', 'ivan@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Петр', N'Петров', N'Петрович', '0987654321', 'petr@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Алексей', N'Сидоров', N'Алексеевич', '5555555555', 'alex@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Екатерина', N'Ковалева', N'Дмитриевна', '9876543210', 'ekaterina@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Мария', N'Смирнова', N'Александровна', '1111111111', 'maria@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Андрей', N'Федоров', N'Викторович', '2222222222', 'andrey@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Ольга', N'Морозова', N'Петровна', '3333333333', 'olga@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Сергей', N'Волков', N'Андреевич', '4444444444', 'sergey@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Татьяна', N'Козлова', N'Игоревна', '6666666666', 'tatiana@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Дмитрий', N'Зайцев', N'Сергеевич', '7777777777', 'dmitry@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Анастасия', N'Павлова', N'Владимировна', '8888888888', 'anastasia@example.com')
INSERT INTO Customer (Name, Surname, Patronymic, Phone, Email) VALUES  (N'Виктор', N'Николаев', N'Викторович', '9999999999', 'victor@example.com')


INSERT INTO Pozition (Name) VALUES (N'синьор-барбер');
INSERT INTO Pozition (Name) VALUES (N'джуниор-барбер');
INSERT INTO Pozition (Name) VALUES (N'чиф-барбер');


INSERT INTO Rating (CustomerRating) VALUES (N'Превосходно');
INSERT INTO Rating (CustomerRating) VALUES (N'Замечательно');
INSERT INTO Rating (CustomerRating) VALUES (N'Отлично');
INSERT INTO Rating (CustomerRating) VALUES (N'Хорошо');
INSERT INTO Rating (CustomerRating) VALUES (N'Удовлетворительно');
INSERT INTO Rating (CustomerRating) VALUES (N'Нормально');
INSERT INTO Rating (CustomerRating) VALUES (N'Средне');
INSERT INTO Rating (CustomerRating) VALUES (N'Плохо');
INSERT INTO Rating (CustomerRating) VALUES (N'Ужасно');
INSERT INTO Rating (CustomerRating) VALUES (N'Без комментариев');




INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'John', N'Smith', N'Doe', 1, N'1234567890', N'john@example.com', '1990-01-01', '2020-01-01', 3)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Michael', N'Johnson', N'Williams', 0, N'0987654321', N'michael@example.com', '1985-05-10', '2018-06-15', 2)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'David', N'Brown', N'Anderson', 1, N'5555555555', N'david@example.com', '1992-09-20', '2019-03-05', 2)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Emma', N'Taylor', N'Wilson', 0, N'9876543210', N'emma@example.com', '1988-12-07', '2017-08-22', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Sophia', N'Miller', N'Thompson', 0, N'1111111111', N'sophia@example.com', '1995-04-15', '2022-02-12', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Daniel', N'Jones', N'Robinson', 1, N'2222222222', N'daniel@example.com', '1993-07-30', '2020-11-18', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Olivia', N'Clark', N'White', 0, N'3333333333', N'olivia@example.com', '1991-03-25', '2019-07-09', 2)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Emily', N'Moore', N'Anderson', 0, N'4444444444', N'emily@example.com', '1994-08-12', '2021-04-02', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'William', N'Lee', N'Harris', 1, N'6666666666', N'william@example.com', '1996-11-05', '2023-01-20', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Ava', N'Thomas', N'Wilson', 0, N'7777777777', N'ava@example.com', '1989-06-18', '2018-09-14', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Sophia', N'Martin', N'Johnson', 0, N'8888888888', N'sophiam@example.com', '1997-02-03', '2020-07-28', 1)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Mason', N'Hall', N'Mitchell', 1, N'9999999999', N'mason@example.com', '1992-10-28', '2019-11-10', 2)
INSERT INTO Barber (Name, Surname, Patronymic, Gender, Phone, Email, Birthday, EmploymentDate, PozitionId)
VALUES    (N'Isabella', N'Walker', N'Robinson', 0, N'1010101010', N'isabella@example.com', '1995-06-07', '2021-03-16', 2)

INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Стрижка', 200, 1);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Бритье', 150, 2);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Окрашивание волос', 300, 3);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Моделирование бороды', 100, 4);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Укладка волос', 250, 5);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Маникюр', 80, 6);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Брови и ресницы', 120, 7);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Уход за кожей', 90, 8);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Массаж головы', 150, 9);
INSERT INTO Service (ServiceName, ServicePrice, BarberId) VALUES (N'Стрижка бороды', 80, 9);


INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (1, 1, 1);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (2, 2, 2);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (3, 3, 3);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (4, 4, 4);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (5, 5, 5);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (6, 6, 6);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (7, 7, 7);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (8, 8, 8);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (9, 9, 9);
INSERT INTO Feedback (CustomerId, BarberId, RatingId) VALUES (10, 10, 10);

INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-21', '09:00:00', 1, 2);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-22', '10:00:00', 2, 2);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-23', '11:00:00', 3, 3);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-24', '12:00:00', 4, 4);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-25', '13:00:00', 5, 1);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-26', '14:00:00', 6, 6);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-27', '15:00:00', 7, 1);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-28', '16:00:00', 8, 8);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-29', '17:00:00', 9, 2);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-30', '18:00:00', 10, 10);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-21', '09:00:00', 1, 1);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-21', '09:00:00', 3, 5);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-27', '15:00:00', 6, 2);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-30', '18:00:00', 2, 3);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-20', '20:00:00', 1, 6);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2022-02-12', '10:00:00', 8, 2);


INSERT INTO Salon (BarberID, Name, Phone, Address)
VALUES
    (1, N'Salon A', N'1234567890', N'123 Main St'),
    (2, N'Salon B', N'9876543210', N'456 Elm St'),
    (3, N'Salon C', N'5555555555', N'789 Oak St'),
    (4, N'Salon D', N'1111111111', N'321 Maple Ave'),
    (5, N'Salon E', N'9999999999', N'654 Pine Rd'),
    (6, N'Salon F', N'2222222222', N'987 Cedar Ln'),
    (7, N'Salon G', N'8888888888', N'234 Birch Dr'),
    (8, N'Salon H', N'7777777777', N'567 Walnut Blvd'),
    (9, N'Salon I', N'4444444444', N'890 Spruce Ave'),
    (10, N'Salon J', N'6666666666', N'123 Cherry St');

--Первая часть
--1.Вернуть информацию о барбере, который работает в барбершопе дольше всех

CREATE FUNCTION LongestOfAllBarberDate()
RETURNS TABLE
as
    RETURN (SELECT * FROM Barber where EmploymentDate = (select MIN(EmploymentDate) from Barber));


select * from LongestOfAllBarberDate()

--2. Вернуть информацию о барбере, который обслужил максимальное количество клиентов в указанном диапазоне дат. Даты передаются в качестве параметра

CREATE FUNCTION dbo.GetBarberWithMaxClientsInRange(@start_date DATE, @end_date DATE)
RETURNS TABLE
    AS
    RETURN
    (SELECT TOP 1 BarberID, Barber.Name, Surname, COUNT(CustomerID) as [Costumer Count]
    FROM Schedule
    JOIN Barber ON Barber.Id = Schedule.BarberID
    WHERE Date BETWEEN @start_date AND @end_date
    GROUP BY BarberID, Barber.Name, Surname
    ORDER BY COUNT(CustomerID) DESC);



SELECT TOP 1 BarberID, Barber.Name, Surname, COUNT(CustomerID)
FROM Schedule
JOIN Barber ON Barber.Id = Schedule.BarberID
WHERE Date BETWEEN '2022-02-05' AND '2023-05-30'
GROUP BY BarberID, Barber.Name, Surname
ORDER BY COUNT(CustomerID) DESC

select * from GetBarberWithMaxClientsInRange ( '2022-02-05', '2023-05-30')


--3 Вернуть информацию о клиенте, который посетил барбершоп максимальное количество раз
CREATE FUNCTION dbo.MostVisitedCustomer()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 1 Customer.id, Customer.Name, Customer.Surname,Customer.Patronymic, Customer.Email, COUNT(CustomerID)  as [Count] from Customer
    JOIN Schedule on Schedule.CustomerID = Customer.Id
    GROUP by Customer.id, Customer.Name, Customer.Surname,Customer.Patronymic, Customer.Email
    ORDER BY COUNT(CustomerID) DESC
);


--4.Вернуть информацию о клиенте, который потратил в барбершопе максимальное количество денег
CREATE FUNCTION RichestCustomer()
RETURNS TABLE
AS
RETURN (
    SELECT top 1 Customer.Id, Name, Surname, Patronymic, SUM(ServicePrice) AS [Сумма]
    FROM Customer
    JOIN Schedule ON Customer.Id = Schedule.CustomerID
    JOIN Service ON Schedule.BarberID = Service.BarberId
    GROUP BY Customer.Id, Name, Surname, Patronymic
    ORDER BY SUM(ServicePrice) DESC
);


select * from RichestCustomer()


--Вторая часть
--1.Вернуть информацию о самом популярном барбере (по количеству клиентов)
CREATE FUNCTION dbo.TheMostPopularBarber()
RETURNS TABLE
    AS
    RETURN
    (SELECT TOP 1 BarberID, Barber.Name, Surname, COUNT(CustomerID) as [Costumer Count]
    FROM Schedule
    JOIN Barber ON Barber.Id = Schedule.BarberID
    GROUP BY BarberID, Barber.Name, Surname
    ORDER BY COUNT(CustomerID) DESC);

select * from TheMostPopularBarber()
--2.Вернуть топ-3 барберов за месяц (по сумме денег, потраченной клиентами)


CREATE FUNCTION RichestBarber()
RETURNS TABLE
AS
RETURN (
    select Top 3 Barber.ID,Name,Surname, sum(ServicePrice)
    from Barber
    join Schedule on Barber.Id = Schedule.BarberID
    join Service  on Barber.Id = Service.BarberId
    where YEAR(Date) = YEAR(dateadd(month, -1,getdate()))
    GROUP BY Barber.Id, Name, Surname
    ORDER BY SUM(ServicePrice) desc
);
select * from RichestBarber()

--3.Вернуть топ-3 барберов за всё время (по средней оценке). Количество посещений клиентов не меньше 30
CREATE FUNCTION BestBarber()
RETURNS TABLE
AS
RETURN (
    select Top 3 Barber.ID,Name,Surname, sum(ServicePrice)
    from Barber
    join Schedule on Barber.Id = Schedule.BarberID
    join Service  on Barber.Id = Service.BarberId
    where YEAR(Date) = YEAR(dateadd(month, -1,getdate()))
    GROUP BY Barber.Id, Name, Surname
    ORDER BY SUM(ServicePrice) desc
);
select * from BestBarber()

--4.Показать расписание на день конкретного барбера. Информация о барбере и дне передаётся в качестве параметра

CREATE FUNCTION BarberSchedules(@barbarName nvarchar, @day date)
RETURNS TABLE AS
RETURN (
    select name, surname, patronymic, gender, phone, email, birthday, employmentdate, pozitionid, date, time, barberid, customerid from Barber
    INNER join Schedule on Barber.Id = Schedule.BarberID
    where Name = @barbarName and Date = @day
);

select * from BarberSchedules('John','2023-05-11')

--5.Показать свободные временные слоты на неделю конкретного барбера. Информация о барбере и дне передаётся в качестве параметра

CREATE FUNCTION FreeBarber(@barberId int, @day date)
RETURNS TABLE
AS
RETURN (
    SELECT Schedule.id, Schedule.Date,Schedule.Time
    FROM Schedule
    WHERE BarberID = @barberId
    AND Date = @day
    AND Time  IN (
    SELECT Time
    FROM Schedule
    WHERE BarberID = 1
    AND Date between date and DATEADD(day , 7,date))
);




select * from BestBarber(1, '2023-05-23')


--6.Перенести в архив информацию о всех уже завершенных услугах (это те услуги, которые произошли в прошлом)

CREATE PROCEDURE FinalServices(@barberId int, @day date)
as
    begin
        SELECT * FROM Schedule
        WHERE BarberID = @barberId
        AND Date = @day AND Time NOT IN(
        SELECT Time
        FROM Schedule
        WHERE BarberID = 1
        AND Date between date and DATEADD(day , 7,date))
    END

execute FinalServices 1,getdate

--7.Запретить записывать клиента к барберу на уже занятое время и дату

CREATE TRIGGER PreventDoubleBooking ON Schedule
FOR INSERT
    AS BEGIN
     declare @date date set @date = (select Date from inserted);
     declare @time time set @time = (select Time from inserted);
     declare @barberId int set @barberId = (select BarberID from inserted);
     declare @count int set @count = (SELECT COUNT (*) as [Count] FROM Schedule
                                    WHERE BarberID = @barberId
                                    AND Time = @time
                                    AND Date = @date)

        if(@count) = 1
        begin
         raiserror(N'Время и дата уже заняты', 16, 1);
        end

END

INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-05-21', '09:00:00', 1, 2);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-06-21', '19:00:00', 2, 3);
INSERT INTO Schedule (Date, Time, BarberID, CustomerID) VALUES ('2023-06-25', '12:00:00', 4, 1);

--8.Запретить добавление нового джуниор-барбера, если в салоне уже работают 5 джуниор-барберов
CREATE TRIGGER MORETHANFIVEJUINOR
ON Barber
FOR INSERT
    AS
BEGIN
     DECLARE @junbarbers int set @junbarbers = ( SELECT COUNT(*) as [count] from Barber WHERE Barber.PozitionId = 2)
     if(@junbarbers >= 5)
         begin
         raiserror(N'Больше 5 джунов нельзя', 16, 1);
         end
END


--9.Вернуть информацию о клиентах, которые не поставили ни одного фидбека и ни одной оценки

CREATE FUNCTION EMPTYFEEDBACK()
RETURNS TABLE
AS
RETURN (
    SELECT *
    FROM Customer
    LEFT JOIN Feedback on Customer.Id = Feedback.CustomerId
    WHERE Feedback.Id IS NULL

);

--10..Вернуть информацию о клиентах, которые не посещали барбершоп свыше одного года

CREATE FUNCTION dbo.NoCustomer()
RETURNS TABLE
AS
RETURN (
    SELECT  Customer.Name, Customer.Surname,Customer.Patronymic
    FROM Customer
    JOIN Schedule on Customer.Id = Schedule.CustomerID
    WHERE DATEDIFF(day ,Schedule.Date,getdate()) > 365
);


