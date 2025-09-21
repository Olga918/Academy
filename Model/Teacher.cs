using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СвязьМеждуТаблицами.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public bool isProfessor { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Surname { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    }
}
