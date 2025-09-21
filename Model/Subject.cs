using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СвязьМеждуТаблицами.Model
{
    public class SubJect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
       
    }
}
