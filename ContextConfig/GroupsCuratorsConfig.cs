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
    public class GroupsCuratorsConfig : IEntityTypeConfiguration<Model.GroupsCurators>
    {
        public void Configure(EntityTypeBuilder<GroupsCurators> tb)
        {
            tb.HasKey(gc => gc.Id);
            tb.Property(gc => gc.Id)
                  .ValueGeneratedOnAdd();

            tb.HasOne(gc => gc.Curator)
                  .WithMany(c => c.GroupsCurators)
                  .HasForeignKey(gc => gc.CuratorId)
                  .IsRequired();
            tb.HasOne(gc => gc.Group)
                  .WithMany(g => g.GroupsCurators)
                  .HasForeignKey(gc => gc.GroupId)
                  .IsRequired();
        }
    }
}
