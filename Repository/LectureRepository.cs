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
    public class LectureRepository : IBaseRepository<Lecture>
    {
        public int Insert(Lecture entity)
        {
            using (var db = new AcademyContext())
            {
                db.Lectures.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(Lecture entity)
        {
            using (var db = new AcademyContext())
            {
                db.Lectures.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Lecture entity)
        {
            using (var db = new AcademyContext())
            {
                db.Lectures.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Lecture> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Lectures.ToList();
            }
        }
        //public Group GetByName(string name)
        //{
        //    using (var db = new AcademyContext())
        //    {
        //        return db.Groups.FirstOrDefault(c => c.Name == name);
        //    }
        //}

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
        public Lecture GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Lectures.Find(id);
            }
        }

        
    }
}
