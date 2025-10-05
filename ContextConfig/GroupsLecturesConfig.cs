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
    public class GroupsLecturesConfig : IEntityTypeConfiguration<GroupsLectures>

    {
        

        public void Configure(EntityTypeBuilder<GroupsLectures> tb)
        {
            tb.HasKey(gl => gl.Id);
            tb.Property(gl => gl.Id).ValueGeneratedOnAdd();

            tb.HasOne(gl => gl.Group)
                  .WithMany(g => g.GroupsLectures)
                  .HasForeignKey(gl => gl.GroupId)
                  .IsRequired();

            tb.HasOne(gl => gl.Lecture)
                  .WithMany(l => l.GroupsLectures)
                  .HasForeignKey(gl => gl.LectureId)
                  .IsRequired();
        }
    }

    
}
