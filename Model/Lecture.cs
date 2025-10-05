using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class Lecture
    {
        public int Id { get; set; }
        public  DateTime Date { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<GroupsLectures> GroupsLectures { get; set; } = new List<GroupsLectures>();
    }
}
