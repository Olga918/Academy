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
    public class SubjectRepository : IBaseRepository<Subject>, INameRepository<Subject>
    {
        public int Insert(Subject entity)
        {
            using (var db = new AcademyContext())
            {
                db.Subjects.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(Subject entity)
        {
            using (var db = new AcademyContext())
            {
                db.Subjects.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Subject entity)
        {
            using (var db = new AcademyContext())
            {
                db.Subjects.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Subject> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Subjects.ToList();
            }
        }

        public Subject GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Subjects.Find(id);
            }
        }

        public Subject GetByName(string name)
        {
            using (var db = new AcademyContext())
            {
                return db.Subjects.FirstOrDefault(c => c.Name == name);
            }

        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
