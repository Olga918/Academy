using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СвязьМеждуТаблицами.Model
{
    public class GroupsCurators
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CuratorId { get; set; }
        public Group Group { get; set; }
        public Curator Curator { get; set; }

    }
}
