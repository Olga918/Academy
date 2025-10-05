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
    public class GroupsLecturesRepository : IBaseRepository<GroupsLectures>
    {
        public int Insert(GroupsLectures entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsLectures.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(GroupsLectures entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsLectures.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(GroupsLectures entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsLectures> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsLectures
                         .Include(gl => gl.Group)
                         .Include(gl => gl.Lecture)
                         .ToList();
            }
        }

        public GroupsLectures GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsLectures
                         .Include(gl => gl.Group)
                         .Include(gl => gl.Lecture)
                         .FirstOrDefault(gl => gl.Id == id);
            }
        }

        public GroupsLectures GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
