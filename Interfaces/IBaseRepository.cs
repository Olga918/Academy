using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.Model;
using ExamAcademy.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace ExamAcademy.Interfaces
{
    public interface IBaseRepository<T>
    {
        public int Insert(T entity);
        public bool Delete(T entity);
        public void Update(T entity);
        public IEnumerable<T> Select();
        public T GetById(int id);
        


    }
}
