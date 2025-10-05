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
    public class TeacherRepository : IBaseRepository<Teacher>, INameRepository<Teacher>
    {
        public int Insert(Teacher entity)
        {
            using (var db = new AcademyContext())
            {
                db.Teachers.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(Teacher entity)
        {
            using (var db = new AcademyContext())
            {
                db.Teachers.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Teacher entity)
        {
            using (var db = new AcademyContext())
            {
                db.Teachers.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Teacher> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Teachers.ToList();
            }
        }

        public Teacher GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Teachers.Find(id);
            }
        }

        

        public Teacher GetByName(string name)
        {
            string[] sabs = name.Split(' ');

            using (var db = new AcademyContext())
            {
                if (sabs.Length == 1)
                {
                    return db.Teachers.FirstOrDefault(c => c.Surname == name);
                }
                else if (sabs.Length == 2)
                {
                    return db.Teachers.FirstOrDefault(c =>
                        (c.Name == sabs[0] && c.Surname == sabs[1])
                    );
                }
                else
                {
                    return null; // <- добавили на случай, если имя в непредвиденном формате
                }
            }
        }
        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
