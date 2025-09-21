using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СвязьМеждуТаблицами.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Surname { get; set; }
       
        public ICollection<GroupsStudents> GroupsStudents { get; set; } = new List<GroupsStudents>();


    }
}
