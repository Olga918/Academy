using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class Group
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Year { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<GroupsStudents> GroupsStudents { get; set; } = new List<GroupsStudents>();
        public ICollection<GroupsLectures> GroupsLectures { get; set; } = new List<GroupsLectures>();
        public ICollection<GroupsCurators> GroupsCurators { get; set; } = new List<GroupsCurators>();
    }
}
