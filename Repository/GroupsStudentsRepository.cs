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
    public class GroupsStudentsRepository : IBaseRepository<GroupsStudents>
    {
        public int Insert(GroupsStudents entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsStudents.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(GroupsStudents entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsStudents.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(GroupsStudents entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsStudents> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsStudents.ToList();
            }
        }

        public GroupsStudents GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsStudents
                         .Include(gl => gl.Group)
                         .Include(gl => gl.Student)
                         .FirstOrDefault(gl => gl.Id == id);
            }
        }

        
    }
}
