using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Interfaces
{
    public interface INameRepository<T>
    {
        public T GetByName(string name);
        public int GetIdByName(string name);
    }

    
}
