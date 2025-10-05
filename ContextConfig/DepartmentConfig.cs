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
    public class DepartmentConfig: IEntityTypeConfiguration<Department>
       
    {


       

        public void Configure(EntityTypeBuilder<Department> tb)
        {
            tb.HasKey(d => d.Id);
            tb.Property(d => d.Id).ValueGeneratedOnAdd();
            tb.Property(d => d.Name).IsRequired().HasMaxLength(100);
            tb.Property(d => d.Building).IsRequired().HasMaxLength(100);
            tb.Property(d => d.Financing).IsRequired().HasMaxLength(100);
            tb.HasOne(d => d.Faculty)
                  .WithMany(f => f.Departments)
                  .HasForeignKey(d => d.FacultyId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
