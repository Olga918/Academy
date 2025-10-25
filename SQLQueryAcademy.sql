USE AcademyEFDB

--Напишіть запити викоритовуючи різні типи запитів: LINQ to Entityes, методи розширення,  прямі запити до сервера SQL    FromSQL.

--(див останню пару )
--0.Вывести номера корпусов, если суммарный фонд финансирования расположенных в них кафедр превышает 100000.
SELECT Building, SUM(Financing) AS Summa
FROM Departments
GROUP BY Building 
HAVING SUM(Financing)>100000

SELECT Building
FROM Departments
GROUP BY Building 
HAVING SUM(Financing)>100000


--1.Вывести названия групп 5-го курса кафедры «Software Development», которые имеют более 10 пар в первую неделю.
SELECT g.Name AS GroupName, COUNT(l.Id) AS LectureCount
FROM Groups AS g
JOIN Departments AS d ON  g.DepartmentId = d.Id
JOIN GroupsLectures AS gl ON gl.GroupId = g.Id
JOIN Lectures AS l ON l.Id = gl.LectureId
WHERE d.Name = N'Департамент программирования' AND g.Year = 5 AND l.Date BETWEEN '2025-10-04' AND '2025-10-11'
GROUP BY g.Name
HAVING COUNT(l.Id)>10  




-- 2. Проверим лекции за любой период
SELECT TOP 10 l.ID, l.Date, l.SubjectId 
FROM Lectures l
ORDER BY l.Date DESC;

-- 3. Проверим расписание лекций для групп
SELECT TOP 10 gl.GroupId, gl.LectureId, l.Date
FROM GroupsLectures gl
JOIN Lectures l ON l.ID = gl.LectureId;




SELECT *FROM Groups WHERE Year = 5
SELECT * FROM Departments


SELECT *
FROM GroupsLectures
WHERE GroupId IN(SELECT Id FROM Groups WHERE Year = 5)

SELECT 
    g.Name AS [Groups],
    COUNT(l.Id) AS [GroupsLectures]
FROM Groups AS g
JOIN Departments AS d 
    ON g.DepartmentId = d.Id
LEFT JOIN GroupsLectures AS gl 
    ON gl.GroupId = g.Id
LEFT JOIN Lectures AS l 
    ON l.Id = gl.LectureId
WHERE 
    d.Name = N'Департамент программирования'
    AND g.Year = 5
GROUP BY 
    g.Name;

	


	

-- Сколько лекций в первую неделю октября
SELECT * 
FROM Lectures
WHERE Date >= '2025-10-01' AND Date < '2025-10-08';


     

--2.Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) больше, чем рейтинг группы «D221





SELECT g.Name AS GroupName, AVG(s.Rating) AS AvgRating
FROM Students AS s
JOIN GroupsStudents AS sg ON s.Id = sg.StudentId
JOIN Groups AS g ON sg.GroupId = g.Id
GROUP BY g.Name
HAVING AVG(s.Rating) > (
    SELECT AVG(s2.Rating)
    FROM Students AS s2
    JOIN GroupsStudents AS sg2 ON s2.Id = sg2.StudentId
    JOIN Groups AS g2 ON sg2.GroupId = g2.Id
    WHERE g2.Name = N'B1'
);

--3.Вывести фамилии и имена преподавателей, ставка которых выше средней ставки профессоров.

SELECT t.Surname, t.Name,t.Salary
FROM Teachers AS t
WHERE t.Salary > (
    SELECT AVG(Salary)
	FROM Teachers
	WHERE isProfessor = 1) 

SELECT t.Surname, t.Name, t.Salary, (SELECT AVG(Salary) FROM Teachers WHERE IsProfessor = 1) AS AvgProfessorSalary
FROM Teachers AS t
WHERE t.Salary > (
    SELECT AVG(Salary) 
    FROM Teachers 
    WHERE IsProfessor = 1
);

	
--4.Вывести названия групп, у которых больше одного куратора.
SELECT g.Name AS Groupsname, COUNT(gc.CuratorId) AS CuratorCount
FROM Groups AS g
JOIN GroupsCurators AS gc ON g.Id = gc.GroupId
GROUP BY g.Name; --Выводит и группы и кураторов


SELECT g.Name AS Groupsname
FROM  Groups AS g
JOIN GroupsCurators AS gc ON g.Id = gc.GroupId
GROUP BY g.Name
HAVING COUNT(gc.CuratorId)> 1   --Здесь выводит только колонку без данных





--5.Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) меньше, чем минимальный рейтинг групп 5-го курса.
SELECT g.Name, AVG(s.Rating) AS AvgRating
FROM Groups AS g
JOIN GroupsStudents AS gs ON g.Id = gs.GroupId
Join Students AS s ON gs.StudentId = s.Id
GROUP BY g.Name
HAVING AVG(s.Rating) < (
    SELECT MIN(s2.Rating)
	FROM Students AS s2
	JOIN GroupsStudents AS gs2 ON s2.Id = gs2.StudentId
	JOIN Groups AS g2 ON gs2.GroupId = g2.Id
	WHERE g2.Year = 5
	)
	ORDER BY AvgRating  --Не вываодит данные

	

SELECT g.Id AS GroupID, g.Name AS GroupName, AVG(s.Rating) AS AvgRating
FROM Groups AS g
JOIN GroupsStudents AS gs ON g.Id = gs.GroupId
JOIN Students AS s ON gs.StudentId = s.Id
GROUP BY g.Id, g.Name
ORDER BY AvgRating;  


--6.Вывести названия факультетов,
--суммарный фонд финансирования кафедр которых больше суммарного фонда финансирования кафедр факультета «Computer Science». 
--Для этого запроса напишите процедуру, и вызовите  в коде процедуру



--CREATE PROCEDURE GetFacultiesWithHigherFunding
--AS
--BEGIN
--    -- Сумма финансирования факультета "Computer Science"
--    DECLARE @CS_Funding MONEY;

--    SELECT @CS_Funding = SUM(d.Financing)
--    FROM Departments d
--    JOIN Faculties f ON d.FacultyId = f.Id
--    WHERE f.Name = N'Computer Science';

    


--INSERT INTO Faculties (Name)
--VALUES (N'Computer Science');

--SELECT f.Name AS FacultyName, SUM(d.Financing) AS TotalFunding
--FROM Faculties f
--LEFT JOIN Departments d ON f.Id = d.FacultyId
--GROUP BY f.Name
--ORDER BY TotalFunding DESC;

--DECLARE @CS_Funding MONEY;

-- Сумма финансирования факультета "Computer Science"
SELECT @CS_Funding = ISNULL(SUM(d.Financing),0)
FROM Departments d
JOIN Faculties f ON d.FacultyId = f.Id
WHERE f.Name = N'Computer Science';

-- Теперь можно использовать переменную
SELECT f.Name AS FacultyName,
       SUM(d.Financing) AS TotalFunding,
       CASE WHEN SUM(d.Financing) > @CS_Funding THEN 'Больше' ELSE 'Меньше' END AS CompareWithCS
FROM Departments d
JOIN Faculties f ON d.FacultyId = f.Id
GROUP BY f.Name
ORDER BY TotalFunding DESC;

--7.Вывести названия дисциплин и полные имена преподавателей, читающих наибольшее количество лекций по ним.

WITH LectureCounts AS (
    SELECT 
        l.SubjectId AS SubjectId,
        t.Id AS TeacherId,
        COUNT(*) AS LectureCount
    FROM Lectures l
    JOIN Teachers t ON l.TeacherId = t.Id
    GROUP BY l.SubjectId, t.Id
),
MaxCounts AS (
    SELECT 
        SubjectId,
        MAX(LectureCount) AS MaxLectureCount
    FROM LectureCounts
    GROUP BY SubjectId
)
SELECT 
    s.Name AS DisciplineName,
    t.Name + N' ' + t.Surname AS TeacherFullName,
    lc.LectureCount
FROM LectureCounts lc
JOIN MaxCounts mc 
    ON lc.SubjectId = mc.SubjectId AND lc.LectureCount = mc.MaxLectureCount
JOIN Subjects s ON lc.SubjectId = s.Id
JOIN Teachers t ON lc.TeacherId = t.Id
ORDER BY s.Name;

--8.Вывести название дисциплины, по которому читается меньше всего лекций.

SELECT s.Name AS DisciplineName, lc.LectureCount
FROM (
    SELECT l.SubjectId AS SubjectId, COUNT(*) AS LectureCount
    FROM Lectures l
    GROUP BY l.SubjectId
) AS lc
JOIN Subjects s ON lc.SubjectId = s.Id
WHERE lc.LectureCount = (
    SELECT MIN(lc2.LectureCount)
    FROM (
        SELECT l.SubjectId AS SubjectId, COUNT(*) AS LectureCount
        FROM Lectures l
        GROUP BY l.SubjectId
    ) AS lc2
);



--9.Вывести количество студентов и читаемых дисциплин на кафедре «Software Development»



SELECT 
    d.Name AS DepartmentName,
    COUNT(DISTINCT sg.StudentId) AS StudentCount,
    COUNT(DISTINCT subj.ID) AS DisciplineCount
FROM Departments d
LEFT JOIN Groups g ON g.DepartmentId = d.ID
LEFT JOIN GroupsStudents sg ON sg.GroupId = g.ID
LEFT JOIN GroupsLectures gl ON gl.GroupId = g.ID
LEFT JOIN Lectures l ON l.ID = gl.LectureId
LEFT JOIN Subjects subj ON subj.ID = l.SubjectId
WHERE d.Name = N'Software Development'
GROUP BY d.Name;



--10.Выполните в коде Вставку новой дисциплины,
--затем выполните изменение ее название, далее удалите выполняя команды SQL  со стороны SQL клиента

-- 1. Вставка новой дисциплины
INSERT INTO Subjects (Name)
VALUES ('Electronic');

-- Проверяем что дисциплина добавилась
SELECT * FROM Subjects;

-- 2. Изменение названия дисциплины
UPDATE Subjects 
SET Name = N'Продвинутые базы данных'
WHERE ID = 12;

-- Проверяем изменение
SELECT * FROM Subjects WHERE ID = 12;

-- 3. Удаление дисциплины
DELETE FROM Subjects 
WHERE ID = 12;

-- Проверяем что дисциплина удалилась
SELECT * FROM Subjects;