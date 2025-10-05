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
   

    public class SubjectConfig : IEntityTypeConfiguration<Subject>

    {
        public void Configure(EntityTypeBuilder<Subject> tb)
        {

            tb.HasKey(s => s.Id);

            tb.Property(s => s.Id)
                  .ValueGeneratedOnAdd();

            tb.Property(s => s.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            tb.HasIndex(s => s.Name)
                  .IsUnique();

        }


    }

}

    

