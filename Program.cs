using ExamAcademy.Model;
using ExamAcademy.Repository;
using System;
using System.Collections.Generic;
using ExamAcademy.Controller;

namespace ExamAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var controler = new AcademyController();

            ///////////////////////////////////////////////


            //controler.AddCurators();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteCurators();
            //Console.WriteLine("нажмите энтер для работы с департментом");
            //Console.ReadLine();
            //controler.DepartmentDataAll();

            ////////////////////////////////////////////////////


            //controler.AddFaculties();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteFaculty();
            //Console.WriteLine("нажмите энтер для работы с группами");
            //Console.ReadLine();
            /////////////////////////////////////////////////


            //controler.AddDepartment();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            ////////////////////////////////////////////////////


            //controler.AddGroups();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteGroup();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////


            //controler.AddStudents();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteStudent();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////


            //controler.AddSubject();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteSubject();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////


            //controler.AddTeacher();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteTeacher();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////


            //controler.AddLectures();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteLectures();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();


            ////////////////////////////////////////////////


            //controler.AddGroupsCurators();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteGroupsCurators();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////

            //controler.AddGroupsLectures();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            //controler.DeleteGroupsLectures();
            //Console.WriteLine("нажмите энтер для выхода");
            //Console.ReadLine();

            ////////////////////////////////////////////////


            //controler.AddGroupsStudents();
            //Console.WriteLine("Данные добавлены и нажмите энтер для удаления.");
            //Console.ReadLine();

            controler.DeleteGroupsStudents();
            Console.WriteLine("нажмите энтер для выхода");
            Console.ReadLine();

















            //// 2️ Получаем куратора по Id
            //var curator = curatorRepo.GetById(newId);
            //Console.WriteLine($"Куратор: {curator.Name} {curator.Surname}");

            //// 3️ Получаем всех кураторов
            //var allCurators = curatorRepo.Select();
            //Console.WriteLine("Все кураторы в базе:");
            //foreach (var c in allCurators)
            //{
            //    Console.WriteLine($"{c.Id}: {c.Name} {c.Surname}");
            //}

            //// 4️ Обновляем куратора
            //curator.Name = "Пётр";
            //curatorRepo.Update(curator);
            //Console.WriteLine("Имя куратора обновлено.");

            //// 5️ Удаляем куратора
            //bool deleted = curatorRepo.Delete(curator);
            //Console.WriteLine($"Куратор удалён: {deleted}");


            ////////////////////////////////////////////////







            //////////////////////////////////////////////////////


            //    var facultyRepo = new FacultyRepository();

            //    // 1️ Получаем все факультеты
            //    var allFaculties = facultyRepo.Select();

            //    // 2️ Удаляем каждый факультет
            //    foreach (var f in allFaculties)
            //    {
            //        facultyRepo.Delete(f);
            //        Console.WriteLine($"Удалён факультет: {f.Name}");
            //    }

            //    Console.WriteLine("Все старые факультеты удалены.");


            //    // Список новых факультетов
            //    var faculties = new List<Faculty>
            //{
            //    new Faculty { Name = "Факультет информатики" },
            //    new Faculty { Name = "Факультет экономики" },
            //    new Faculty { Name = "Факультет физики" },
            //    new Faculty { Name = "Факультет химии" },
            //    new Faculty { Name = "Факультет биологии" }
            //};

            //    // Добавляем факультеты в базу
            //    foreach (var f in faculties)
            //    {
            //        facultyRepo.Insert(f);
            //        Console.WriteLine($"Добавлен факультет: {f.Name}");
            //    }
            //    // 2️⃣ Проверяем базу — выводим все факультеты


            //    Console.WriteLine("\nВсе факультеты в базе:");
            //    foreach (var f in allFaculties)
            //    {
            //        Console.WriteLine($"Id: {f.Id}, Name: {f.Name}");
            //    }

            /////////////////////////////////////////////

            var groupRepo = new GroupRepository();
            // 1️⃣ Получаем все группы
            var allGroups = groupRepo.Select();









        }

    }
}
