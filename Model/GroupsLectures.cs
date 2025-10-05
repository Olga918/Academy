using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Model
{
    public class GroupsLectures
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LectureId { get; set; }
        public Group Group { get; set; }
        public Lecture Lecture { get; set; }


    }
}
