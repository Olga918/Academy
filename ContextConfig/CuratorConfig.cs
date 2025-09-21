using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СвязьМеждуТаблицами.Model;

namespace СвязьМеждуТаблицами.ContextConfig
{
    public class CuratorConfig : IEntityTypeConfiguration<Curator>
    {
        public void Configure(EntityTypeBuilder<Curator> tb)
        {


            tb.HasKey(c => c.Id);
            tb.Property(c => c.Id).ValueGeneratedOnAdd();
            tb.Property(c => c.Name).IsRequired().HasMaxLength(100);
            tb.Property(c => c.Surname).IsRequired().HasMaxLength(100);
        }
    }
}
