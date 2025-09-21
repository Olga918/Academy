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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>

    {
        public void Configure(EntityTypeBuilder<Teacher> tb)
        {

            // Первичный ключ
            tb.HasKey(t => t.Id);

            // Id — автоприрост
            tb.Property(t => t.Id)
                  .ValueGeneratedOnAdd();

            // IsProfessor — BIT, NOT NULL, default false
            tb.Property(t => t.isProfessor)
                  .IsRequired()
                  .HasDefaultValue(false);

            // Name — nvarchar(max), NOT NULL
            tb.Property(t => t.Name)
                  .IsRequired()
                  .HasColumnType("nvarchar(max)");

            // Surname — nvarchar(max), NOT NULL
            tb.Property(t => t.Surname)
                  .IsRequired()
                  .HasColumnType("nvarchar(max)");

            // Salary — int, NOT NULL, > 0
            tb.Property(t => t.Salary)
                  .IsRequired();
            tb.HasCheckConstraint("CK_Teacher_Salary", "[Salary] > 0");

        }


    }
}
