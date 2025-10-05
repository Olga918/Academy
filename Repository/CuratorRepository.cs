using Microsoft.EntityFrameworkCore;
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
    public class CuratorRepository : IBaseRepository<Curator>, INameRepository<Curator>
    {
        public int Insert(Curator entity)
        {
            using (var db = new AcademyContext()) 
            {
                db.Curators.Add(entity);          
                db.SaveChanges();
                return entity.Id;                 
            }
        }
        public bool Delete(Curator entity)
        {
            using (var db = new AcademyContext())
            {
                db.Curators.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }
        public void Update(Curator entity)
        {
            using (var db = new AcademyContext())
            {
                db.Curators.Update(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Curator> Select()
        {
            using (var db = new AcademyContext())
            {
                return db.Curators.ToList();
            }
        }

        public Curator GetById(int id)
        {
           using (var db = new AcademyContext())
            {
                return db.Curators.Find(id);
            }
        }

        public Curator GetByName(string name)
        {
            string[] sabs = name.Split(' ');
            if (sabs.Length == 1)
            {
                using (var db = new AcademyContext())
                {
                    return db.Curators.FirstOrDefault(c => c.Surname == name);
                }
            }
            else if (sabs.Length == 2)
            {
                using (var db = new AcademyContext())
                {
                    return db.Curators.FirstOrDefault(c => /*(c.Surname == sabs[0] && c.Name == sabs[1]) ||*/ (c.Name == sabs[0] && c.Surname == sabs[1]));
                }
            }
            
            else
            {
                throw new ArgumentException("Ожидается параметр Фамилия или Имя Фамилии");
            }
            
            
        }

        public int GetIdByName(string name)
        {
            var d = GetByName(name);
            return d.Id;
        }
    }
}