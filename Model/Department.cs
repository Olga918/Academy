using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class Department
    {
        public int Id { get; set; }
        public int Building { get; set; }
        public double Financing { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Group> Groups { get; set; } = new List<Group>();

    }
}
