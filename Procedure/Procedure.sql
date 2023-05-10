use College

--1
create function GetTeacherCount()
returns int
as
    begin
       return (select count(*) from Teacher)
    end

select GetTeacherCount();

--2
create function GetTeacherByName(@name varchar)
returns table
        return
        (select * from Teacher where Name = @name)

select * from GetTeacherByName('Edvard')


-----3
create function  GetHeadsName()
returns table
    as
    return
        (select Name,Surname from Teacher inner join Deans on Teacher.Id = Deans.TeacherId);

select * from GetHeadsName()



-- 4
create function GetOldesGroup()
returns int
    as
    begin
        return (select MAX([Group].Year) from [Group])
    end


select dbo.GetOldesGroup()