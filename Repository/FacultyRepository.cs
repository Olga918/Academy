using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using ExamAcademy.ContextConfig;
using Microsoft.EntityFrameworkCore;


namespace ExamAcademy.Repository
{
    public class FacultyRepository : IBaseRepository<Faculty>,INameRepository<Faculty>
    {
        public int Insert(Faculty entity)
        {
            using (var db = new AcademyContext())
            {
                db.Faculties.Add(entity);
                return db.SaveChanges();
            }
        }
        public bool  Delete(Faculty entity)
        {
            using (var db = new AcademyContext())
            {
                db.Faculties.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }

        public void Update(Faculty entity)
        {
            using (var db = new AcademyContext())
            {
                db.Faculties.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Faculty> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Faculties.ToList();
            }
        }

        public Faculty GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Faculties.Find(id);
            }
        }

        public Faculty  GetByName(string name)
        {
            using (var db = new AcademyContext())
            {
                return db.Faculties.FirstOrDefault(c => c.Name == name);
            }
        }

        public int GetIdByName(string name)
        {
           Faculty f = GetByName(name);
            return f.Id;
              

        }
    }
}







