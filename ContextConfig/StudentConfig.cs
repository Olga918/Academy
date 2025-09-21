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
    public class StudentConfig : IEntityTypeConfiguration<Student>

    {
        public void Configure(EntityTypeBuilder<Student> tb)
        {

            tb.HasKey(s => s.Id);
            tb.Property(s => s.Id).ValueGeneratedOnAdd();

            tb.Property(s => s.Name)
                  .IsRequired()
                  .HasColumnType("nvarchar(max)");

            tb.Property(s => s.Surname)
                  .IsRequired()
                 .HasColumnType("nvarchar(max)");

            tb.Property(s => s.Rating)
                  .IsRequired();
            tb.HasCheckConstraint("CK_Student_Rating", "[Rating] >= 0 AND [Rating] <= 5");

        }


    }
}
