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
    public class FacultyConfig : IEntityTypeConfiguration<Faculty>

    {




        public void Configure(EntityTypeBuilder<Faculty> tb)
        {
            tb.HasKey(f => f.Id);
            tb.Property(f => f.Id).ValueGeneratedOnAdd();
            tb.Property(f => f.Name).IsRequired().HasMaxLength(100);
            tb.HasIndex(f => f.Name).IsUnique();
        }
    }
}
