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
    public class GroupsCuratorsRepository : IBaseRepository<GroupsCurators>
    {
        public int Insert(GroupsCurators entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsCurators.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
        }
        public bool Delete(GroupsCurators entity)
        {
            using (var db = new AcademyContext())
            {
                db.GroupsCurators.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(GroupsCurators entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsCurators> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsCurators.ToList();
            }
        }

        public GroupsCurators GetById(int id)
        {
            using (var db = new AcademyContext())
            {
                return db.GroupsCurators
                         .Include(gl => gl.Group)
                         .Include(gl => gl.Curator)
                         .FirstOrDefault(gl => gl.Id == id);
            }
        }

        
    }
}
