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
    public class LectureConfig : IEntityTypeConfiguration<Lecture>

    {
        public void Configure(EntityTypeBuilder<Lecture> tb)
        {

            tb.HasKey(l => l.Id);

            tb.Property(l => l.Id)
                  .ValueGeneratedOnAdd();

            tb.Property(l => l.Date)
                  .IsRequired();
            tb.HasCheckConstraint("CK_Lecture_Date", "[Date] <= GETDATE()");

            tb.HasOne(l => l.Subject)
                  .WithMany(s => s.Lectures)
                  .HasForeignKey(l => l.SubjectId)
                  .IsRequired();

            tb.HasOne(l => l.Teacher)
                  .WithMany(t => t.Lectures)
                  .HasForeignKey(l => l.TeacherId)
                  .IsRequired();
        }


    }
}
