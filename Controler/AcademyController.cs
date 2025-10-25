using ExamAcademy.ContextConfig;
using ExamAcademy.Model;
using ExamAcademy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Controller
{
    public class AcademyController
    {
        private object facultyRepo;
        private object departmentRepo;
        private object curatorRepo;
        private object groupRepo;
        private object studentRepo;
        private object subjectRepo;
        private object teacherRepo;
        private object lecturesRepo;
        private object groupsCuratorsRepo;
        private object groupsStudentsRepo;
        private object groupsLecturesRepo;


        public void AddCurators()
           
        {
            // Создаём репозиторий для кураторов

            var curatorRepo = new CuratorRepository();

            // 1️ Добавляем нового куратора
            var newCurator = new Curator
            {
                Name = "Иван",
                Surname = "Иванов"
            };
            int newId = curatorRepo.Insert(newCurator);
            
            var newCurator1 = new Curator
            {
                Name = "Пётр",
                Surname = "Петров"
            };
            int newId1 = curatorRepo.Insert(newCurator1);

            int newId2 = curatorRepo.Insert(new Curator
            {
                Name = "Сидор",
                Surname = "Сидоров"
            });

            

        }
        public void DeleteCurators() 
        {
            var curatorRepo = new CuratorRepository();
            var CuratorDell = curatorRepo.GetByName("Сидор Сидоров");

            bool deletedCurator = curatorRepo.Delete(CuratorDell);
        }
        public void AddFaculties()

        {
            var facultyRepo = new FacultyRepository();

            // Список новых факультетов с обязательными полями
            var faculties = new List<Faculty>
            {
                new Faculty { Name = "Факультет информационных технологий"  },
                new Faculty { Name = "Факультет бизнеса" },
                new Faculty { Name = "Факультет поддержки" }
            };

            //// Добавляем новые факультеты в базу
            //foreach (var f in faculties)
            //{
            //    facultyRepo.Insert(f);
            //    Console.WriteLine($"Добавлен факультет: {f.Name}");
            //}
            // Добавляем новый факультет в базу
            var newFaculty = new Faculty
            {
                Name = "Факультет C++",
                
            };
            int newId = facultyRepo.Insert(newFaculty);
        }

        public void DeleteFaculty()
        {
            var facultyRepo = new FacultyRepository();
            var FacultyDell = facultyRepo.GetByName("Факультет C++");
            bool deletedFaculty = facultyRepo.Delete(FacultyDell);
        }

        public void AddDepartment()
        {
            var departmentRepo = new DepartmentRepository();
            // Добавляем новый департамент в базу
            var newDepartment = new Department
            {
                Name = "Департамент тестирования",
                Financing = 2,
                Building =5,
                FacultyId = 50
            };

            departmentRepo.Insert(newDepartment);

            var facultyRepo = new FacultyRepository();

            var departments = new List<Department>
            {
                new Department { Name = "Департамент программирования", Financing = 4000, Building = 1, FacultyId = facultyRepo.GetIdByName("Факультет бизнеса") },
                new Department { Name = "Департамент дизайна", Financing = 4500, Building = 4, FacultyId =facultyRepo.GetIdByName("Факультет биологии")  },
                new Department { Name = "Департамент маркетинга", Financing = 1400, Building = 3, FacultyId = 44 },
                new Department { Name = "Департамент продаж", Financing = 5050, Building = 4, FacultyId = 49 },
                new Department { Name = "Департамент поддержки", Financing = 3000, Building = 2, FacultyId = 51 }
    };

            // Добавляем новые департаменты в базу
            foreach (var d in departments)
            {
                departmentRepo.Insert(d);
                Console.WriteLine($"Добавлен департамент: {d.Name}");
            }


            


        }

        public void DeleteDepartment()
        {
            var departmentRepo = new DepartmentRepository();
            var DepartmentDell = departmentRepo.GetByName("Департамент тестирования");
            bool deletedDepartment = departmentRepo.Delete(DepartmentDell);
        }

        public void AddGroups()
        {
        var dRepo = new DepartmentRepository();
            var groupRepo = new GroupRepository();

            //Добавляем новую группу в базу

           var newGroup = new Group
           {
               Name = "Группа A1",
               Year = 3,
               DepartmentId = dRepo.GetIdByName("Департамент программирования")
           };
            groupRepo.Insert(newGroup);
            var groups = new List<Group>
            {
                
                new Group { Name = "Группа B1", Year = 2, DepartmentId = dRepo.GetIdByName("Департамент дизайна") },
                new Group { Name = "Группа C1", Year = 3, DepartmentId = dRepo.GetIdByName("Департамент маркетинга") },
                new Group { Name = "Группа D1", Year = 4, DepartmentId = dRepo.GetIdByName("Департамент продаж") },
                new Group { Name = "Группа E1", Year = 1, DepartmentId = dRepo.GetIdByName("Департамент поддержки") }


            };
            // Добавляем новые группы в базу
            foreach (var g in groups)
            {
                groupRepo.Insert(g);
                Console.WriteLine($"Добавлена группа: {g.Name}");
            }
          


        }
        public void DeleteGroup()
        {
            var groupRepo = new GroupRepository();
            var GroupDell = groupRepo.GetByName("Группа A1");
            bool deletedGroup = groupRepo.Delete(GroupDell);
        }
        public void AddStudents()
        {
            var studentRepo = new StudentRepository();
            // Добавляем нового студента
            var newStudent = new Student
            {
                Name = "Алексей",
                Rating = 5,
                Surname = "Алексеев",
                

               
            };
            studentRepo.Insert(newStudent);
            var students = new List<Student>
            {
                new Student { Name = "Борис", Rating = 4, Surname = "Борисов" },
                new Student { Name = "Виктор", Rating = 3, Surname = "Викторов" },
                new Student { Name = "Григорий", Rating = 5, Surname = "Григорьев" },
                new Student { Name = "Дмитрий", Rating = 2, Surname = "Дмитриев" }
            };
            // Добавляем новых студентов в базу
            foreach (var s in students)
            {
                studentRepo.Insert(s);
                Console.WriteLine($"Добавлен студент: {s.Name} {s.Surname}");
            }



        }
        public void DeleteStudent()
        {
            var studentRepo = new StudentRepository();

            //var StudentDell = studentRepo.GetByName("Алексей Алексеев");
            //bool deletedStudent = studentRepo.Delete(StudentDell);

            var StudentsDell = new List<Student>
            {
                studentRepo.GetByName("Борис Борисов"),
                studentRepo.GetByName("Виктор Викторов"),
                studentRepo.GetByName("Григорий Григорьев"),
                studentRepo.GetByName("Дмитрий Дмитриев")
                
            };
            foreach (var s in StudentsDell)
            {
                bool deletedStudent = studentRepo.Delete(s);
            }
        }
        public void AddSubject()
        {
            var subjectRepo = new SubjectRepository();
            // Добавляем новый предмет в базу
            //var newSubject = new Subject
            //{
            //    Name = "Алгоритмы и структуры данных",
                
            //};
            //subjectRepo.Insert(newSubject);
            var subjects = new List<Subject>
            {
                new Subject { Name = "Основы программирования" },
                new Subject { Name = "Веб-разработка" },
                new Subject { Name = "Маркетинг" },
                new Subject { Name = "Продажи" },
                new Subject { Name = "Поддержка пользователей"}
            };
            //Добавляем новые предметы в базу
            foreach (var s in subjects)
            {
                subjectRepo.Insert(s);
                Console.WriteLine($"Добавлен предмет: {s.Name}");
            }
        }
        public void DeleteSubject()
        {
            var subjectRepo = new SubjectRepository();
            var SubjectDell = subjectRepo.GetByName("Алгоритмы и структуры данных");
            bool deletedSubject = subjectRepo.Delete(SubjectDell);

            

        }
        public void AddTeacher()
            {
            var subjectRepo = new SubjectRepository();
            var teacherRepo = new TeacherRepository();
            // Добавляем нового преподавателя в базу
            //var newTeacher = new Teacher
            //{
            //    isProfessor = true,
            //    Name = "Елена",
            //    Salary = 80000,
            //    Surname = "Еленова",
               
            //};
            //teacherRepo.Insert(newTeacher);

            var teachers = new List<Teacher>
            {
                new Teacher { Name = "Игорь", Salary = 5000, Surname = "Игорев"  },
                new Teacher { Name = "Константин", Salary = 6000, Surname = "Константинов"  },
                new Teacher { Name = "Людмила", Salary = 4000,Surname = "Людмилова" },
                new Teacher { Name = "Марина", Salary = 3000, Surname = "Маринова" }
            };
            // Добавляем новых преподавателей в базу
            foreach (var t in teachers)
            {
                teacherRepo.Insert(t);
                Console.WriteLine($"Добавлен преподаватель: {t.Name} {t.Surname}");
            }
        }
        public void DeleteTeacher()
        {
            var teacherRepo = new TeacherRepository();

            //var TeacherDell = teacherRepo.GetByName("Елена Еленова");
            //bool deletedTeacher = teacherRepo.Delete(TeacherDell);

            var TeachersDell = new List<Teacher>
            {
                teacherRepo.GetByName("Игорь Игорев"),
                teacherRepo.GetByName("Константин Константинов"),
                teacherRepo.GetByName("Людмила Людмилова"),
                teacherRepo.GetByName("Марина Маринова")
            };
            foreach (var t in TeachersDell)
            {
                bool deletedTeacher = teacherRepo.Delete(t);
            }
        }
        public void AddLectures()
        {
            var subjectRepo = new SubjectRepository();
            var teacherRepo = new TeacherRepository();
            var lectureRepo = new LectureRepository();


            //var singleSubject = subjectRepo.GetByName("Основы программирования");
            //var singleTeacher = teacherRepo.GetByName("Игорь Игорев");
            //if (singleSubject != null && singleTeacher != null)
            //{
            //    var singleLecture = new Lecture
            //    {
            //        Date = DateTime.Now,
            //        SubjectId = singleSubject.Id,
            //        TeacherId = singleTeacher.Id
            //    };
            //    lectureRepo.Insert(singleLecture);
            //    Console.WriteLine($"Добавлена лекция для предмета {singleSubject.Name} и преподавателя {singleTeacher.Name} {singleTeacher.Surname} ");
            //}
            //else
            //{
            //    Console.WriteLine("Предмет или преподаватель не найдены. Лекция не добавлена.");
            //}

                       

            //var lectures = new List<Lecture>
            //{
            //    new Lecture { Date = DateTime.Now, SubjectId = 10, TeacherId = 7 },
            //    new Lecture { Date = DateTime.Now, SubjectId = 11, TeacherId = 8 },
            //    new Lecture { Date = DateTime.Now, SubjectId = 3, TeacherId = 9 },
            //    new Lecture { Date = DateTime.Now, SubjectId = 4, TeacherId = 10 }
            //};
            //// Добавляем новые лекции в базу
            //foreach (var l in lectures)
            //{
            //    lectureRepo.Insert(l);
            //    Console.WriteLine($"Добавлена лекция: {l.Date} для предмета {l.SubjectId} и преподавателя {l.TeacherId}");
            //}
            var lectures = new List<Lecture>
            {
                new Lecture { Date = DateTime.Now, SubjectId = 10, TeacherId = 7 },
                new Lecture { Date = DateTime.Now, SubjectId = 11, TeacherId = 8 },
                new Lecture { Date = DateTime.Now, SubjectId = 3, TeacherId = 9 },
                new Lecture { Date = DateTime.Now, SubjectId = 4, TeacherId = 10 }
            };
            // Добавляем новые лекции в базу
            foreach (var l in lectures)
            {
                lectureRepo.Insert(l);
                Console.WriteLine($"Добавлена лекция: {l.Date} для предмета {l.SubjectId} и преподавателя {l.TeacherId}");
            }






        }
        public void DeleteLectures()
        {
            var lectureRepo = new LectureRepository();
            var allLectures = lectureRepo.Select().ToList();
            // Удаляем все лекции
            foreach (var lecture in allLectures)
            {
                lectureRepo.Delete(lecture);
                Console.WriteLine($"Удалена лекция с Id: {lecture.Id}");
            }
            Console.WriteLine("Все лекции удалены.");
        }
        

        public void AddGroupsCurators()
        {
            var grRepo = new GroupsCuratorsRepository();

            //Добавляем новый департамент в базу
            //var newGroupsCurators = new GroupsCurators
            //{

            //   CuratorId = 2,
            //   GroupId = 2
            //};
            //grRepo.Insert(newGroupsCurators);

            
            var groupsCurators = new List<GroupsCurators>
            {
                new GroupsCurators { CuratorId = 35, GroupId = 3 },
                new GroupsCurators { CuratorId = 40, GroupId = 4 },
                new GroupsCurators { CuratorId = 43, GroupId = 5 },
                new GroupsCurators { CuratorId = 53, GroupId = 6 }
            };
            // Добавляем новые департаменты в базу
            foreach (var gc in groupsCurators)
            {
                grRepo.Insert(gc);
                Console.WriteLine($"Добавлен куратор: {gc.CuratorId} для группы {gc.GroupId}");
            }


        }

        public void DeleteGroupsCurators()
        {
            var groupsCuratorsRepo = new GroupsCuratorsRepository();
            var GroupsCuratorsDell = groupsCuratorsRepo.GetById(11);
            bool deletedGroupsCurators = groupsCuratorsRepo.Delete(GroupsCuratorsDell);
        }

        

        public void AddGroupsLectures()
        {
            
            var groupsLecturesRepo = new GroupsLecturesRepository();

            //var newgroupslectures = new GroupsLectures
            //{
            //    GroupId = 3,
            //    LectureId = 6
            //};
            //groupsLecturesRepo.Insert(newgroupslectures);

            var groupslectures = new List<GroupsLectures>
            {
                new GroupsLectures { GroupId = 4, LectureId = 7 },
                new GroupsLectures { GroupId = 3, LectureId = 9 },
                new GroupsLectures { GroupId = 6, LectureId = 10 },
                new GroupsLectures { GroupId = 5, LectureId = 11 }
            };
            // Добавляем новые департаменты в базу
            foreach (var gl in groupslectures)
            {
                groupsLecturesRepo.Insert(gl);
                Console.WriteLine($"Добавлена лекция: {gl.LectureId} для группы {gl.GroupId}");
            }

        }


        public void DeleteGroupsLectures()
        {
            var groupsLecturesRepo = new GroupsLecturesRepository();
           
            var GroupsLecturesDell = groupsLecturesRepo.GetById(6);
            bool deletedGroupsLectures = groupsLecturesRepo.Delete(GroupsLecturesDell);
            


        }




        public void AddGroupsStudents()
        {
            var gsRepo = new GroupsStudentsRepository();
            //Добавляем новый департамент в базу
            //var newGroupsStudents = new GroupsStudents
            //{
            //    StudentId = 11,
            //    GroupId = 3
            //};
            //gsRepo.Insert(newGroupsStudents);

            var groupsStudents = new List<GroupsStudents>
            {
                new GroupsStudents { StudentId = 12, GroupId = 3 },
                new GroupsStudents { StudentId = 13, GroupId = 4 },
                new GroupsStudents { StudentId = 14, GroupId = 5 },
                new GroupsStudents { StudentId = 15, GroupId = 6 }
            };
            // Добавляем новые департаменты в базу
            foreach (var gs in groupsStudents)
            {
                gsRepo.Insert(gs);
                Console.WriteLine($"Добавлен студент: {gs.StudentId} для группы {gs.GroupId}");
            }
        }


        public void DeleteGroupsStudents()
        {
            var groupsStudentsRepo = new GroupsStudentsRepository();
            var GroupsStudentsDell = groupsStudentsRepo.GetById(1);
            bool deletedGroupsStudents = groupsStudentsRepo.Delete(GroupsStudentsDell);
        }





















        public void FacultyDataAll()
        {
            var facultyRepo = new FacultyRepository();
            // Получаем все факультеты
            var allFaculties = facultyRepo.Select().ToList();
            // Удаляем старые факультеты
            foreach (var f in allFaculties)
            {
                facultyRepo.Delete(f);
                Console.WriteLine($"Удалён факультет: {f.Name}");
            }
            Console.WriteLine("Все старые факультеты удалены.");
            
            
            // Проверяем базу и выводим все факультеты
            var checkFaculties = facultyRepo.Select().ToList();
            Console.WriteLine("\nВсе факультеты в базе:");
            foreach (var f in checkFaculties)
            {
                Console.WriteLine($"Id: {f.Id}, Name: {f.Name}");
            }
        }






        public void DepartmentDataAll()
        {
            var departmentRepo = new DepartmentRepository();

            // Получаем все департаменты
            var allDepartments = departmentRepo.Select().ToList();

            // Удаляем старые департаменты
            foreach (var d in allDepartments)
            {
                departmentRepo.Delete(d);
                Console.WriteLine($"Удалён департамент: {d.Name}");
            }
            Console.WriteLine("Все старые департаменты удалены.");

            // Список новых департаментов с обязательными полями
           
    //        var departments = new List<Department>
    //        {
    //            new Department { Name = "Департамент программирования", Financing = "Бюджет", Building = "Главное здание", FacultyId = 1 },
    //            new Department { Name = "Департамент дизайна", Financing = "Бюджет", Building = "Корпус 2", FacultyId = 1 },
    //            new Department { Name = "Департамент маркетинга", Financing = "Бюджет", Building = "Корпус 3", FacultyId = 2 },
    //            new Department { Name = "Департамент продаж", Financing = "Бюджет", Building = "Корпус 4", FacultyId = 2 },
    //            new Department { Name = "Департамент поддержки", Financing = "Бюджет", Building = "Корпус 5", FacultyId = 3 }
    //};

    //        // Добавляем новые департаменты в базу
    //        foreach (var d in departments)
    //        {
    //            departmentRepo.Insert(d);
    //            Console.WriteLine($"Добавлен департамент: {d.Name}");
    //        }

            // Проверяем базу и выводим все департаменты
            var checkDepartments = departmentRepo.Select().ToList();
            Console.WriteLine("\nВсе департаменты в базе:");
            foreach (var d in checkDepartments)
            {
                Console.WriteLine($"Id: {d.Id}, Name: {d.Name}, Building: {d.Building}, Financing: {d.Financing}, FacultyId: {d.FacultyId}");
            }

            

            

        }

        
    }





















    
}
