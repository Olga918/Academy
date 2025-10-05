using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.ContextConfig;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamAcademy.Repository
{
    public class StudentRepository : IBaseRepository<Student>, INameRepository<Student>
    {
        public int Insert(Student entity)
        {
            using (var db = new AcademyContext())
            {
                db.Students.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(Student entity)
        {
            using (var db = new AcademyContext())
            {
                db.Students.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Student entity)
        {
            using (var db = new AcademyContext())
            {
                db.Students.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Student> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Students.ToList();
            }
        }

        public Student GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Students.Find(id);
            }
        }

        

        public Student GetByName(string name)
        {
            string[] sabs = name.Split(' ');
            if (sabs.Length == 1)
            {
                using (var db = new AcademyContext())
                {
                    return db.Students.FirstOrDefault(c => c.Surname == name);
                }
            }
            else if (sabs.Length == 2)
            {
                using (var db = new AcademyContext())
                {
                    return db.Students.FirstOrDefault(c => /*(c.Surname == sabs[0] && c.Name == sabs[1]) ||*/ (c.Name == sabs[0] && c.Surname == sabs[1]));
                }
            }

            else
            {
                throw new ArgumentException("Ожидается параметр Фамилия или Имя Фамилии");
            }


        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
