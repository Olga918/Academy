using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СвязьМеждуТаблицами.Model
{
    public class Curator
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<GroupsCurators> GroupsCurators { get; set; } = new List<GroupsCurators>();


    }
}
