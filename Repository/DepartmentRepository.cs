using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.ContextConfig;
using ExamAcademy.Interfaces;
using ExamAcademy.Model;
using Microsoft.Extensions.Configuration;

namespace ExamAcademy.Repository
{
    public class DepartmentRepository : IBaseRepository<Department>, INameRepository<Department>

    {
        public int Insert(Department entity)
        {
            using (var db = new AcademyContext())
            {
                db.Departments.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(Department entity)
        {
            using (var db = new AcademyContext())
            {
                db.Departments.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Department entity)
        {
            using (var db = new AcademyContext())
            {
                db.Departments.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Department> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Departments.ToList();
            }
        }

        public Department GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Departments.Find(id);
            }
        }

        public Department GetByName(string name)
        {
            using (var db = new AcademyContext())
            {
                return db.Departments.FirstOrDefault(c => c.Name == name);
            }
        }

        public int GetIdByName(string name)
        {
            var d = GetByName(name);
            return d.Id;
        }
    }
}
