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
    public class GroupRepository : IBaseRepository<Group>, INameRepository<Group>
    {
        public int Insert(Group entity)
        {
            using (var db = new AcademyContext())
            {
                db.Groups.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(Group entity)
        {
            using (var db = new AcademyContext())
            {
                db.Groups.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Group entity)
        {
            using (var db = new AcademyContext())
            {
                db.Groups.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Group> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Groups.ToList();
            }
        }

        public Group GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.Groups.Find(id);
            }
        }

        public Group GetByName(string name)
        {
            using (var db = new AcademyContext())
            {
                return db.Groups.FirstOrDefault(c => c.Name == name);
            }
        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

