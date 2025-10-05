using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamAcademy.Model;

namespace ExamAcademy.ContextConfig
{
    public class GroupConfig : IEntityTypeConfiguration<Group>

    {
        public void Configure(EntityTypeBuilder<Group> tb)
        {

            tb.HasKey(g => g.Id);
            tb.Property(g => g.Id).ValueGeneratedOnAdd();
            tb.Property(g => g.Name).IsRequired().HasMaxLength(10);
            tb.HasIndex(f => f.Name).IsUnique();
            tb.Property(g => g.Year).IsRequired();
            tb.HasCheckConstraint("CK_Group_Year", "Year >= 1 AND Year <= 5");
            tb.HasOne(g => g.Department)
                  .WithMany(d => d.Groups)
                  .HasForeignKey(g => g.DepartmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        }

        
    }
}
