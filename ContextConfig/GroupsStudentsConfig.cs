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
    public class GroupsStudentsConfig : IEntityTypeConfiguration<GroupsStudents>

    {


        public void Configure(EntityTypeBuilder<GroupsStudents> tb)
        {
            tb.HasKey(gs => gs.Id);
            tb.Property(gs => gs.Id).ValueGeneratedOnAdd();

            tb.HasOne(gs => gs.Group)
                  .WithMany(g => g.GroupsStudents)
                  .HasForeignKey(gs => gs.GroupId)
                  .IsRequired();

            tb.HasOne(gs => gs.Student)
                  .WithMany(s => s.GroupsStudents)
                  .HasForeignKey(gs => gs.StudentId)
                  .IsRequired();
        }
    }
}
