using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using СвязьМеждуТаблицами.Model;


namespace СвязьМеждуТаблицами.ContextConfig
{
    public class AcademyContext : DbContext
    {
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupsCurators> GroupsCurators { get; set; }
        public DbSet<GroupsLectures> GroupsLectures { get; set; }
        public DbSet<GroupsStudents> GroupsStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<SubJect> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=COSMOS\\SQLEXPRESS;Database=AcademyOfCommucationsDB;Trusted_Connection=True;");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Curator>(entity =>
            //{
            //    entity.HasKey(c => c.Id);
            //    entity.Property(c => c.Id).ValueGeneratedOnAdd();
            //    entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            //    entity.Property(c => c.Surname).IsRequired().HasMaxLength(100);
            //});

            modelBuilder.ApplyConfiguration(new CuratorConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());

            //modelBuilder.Entity<Department>(entity =>
            //{
            //    entity.HasKey(d => d.Id);
            //    entity.Property(d => d.Id).ValueGeneratedOnAdd();
            //    entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
            //    entity.Property(d => d.Building).IsRequired().HasMaxLength(100);
            //    entity.Property(d => d.Financing).IsRequired().HasMaxLength(100);
            //    entity.HasOne(d => d.Faculty)
            //          .WithMany(f => f.Departments)
            //          .HasForeignKey(d => d.FacultyId)
            //          .OnDelete(DeleteBehavior.Cascade);

            //});

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).ValueGeneratedOnAdd();
                entity.Property(f => f.Name).IsRequired().HasMaxLength(100);
                entity.HasIndex(f => f.Name).IsUnique();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Id).ValueGeneratedOnAdd();
                entity.Property(g => g.Name).IsRequired().HasMaxLength(10);
                entity.HasIndex(f => f.Name).IsUnique();
                entity.Property(g => g.Year).IsRequired();
                entity.HasCheckConstraint("CK_Group_Year", "Year >= 1 AND Year <= 5");
                entity.HasOne(g => g.Department)
                      .WithMany(d => d.Groups)
                      .HasForeignKey(g => g.DepartmentId)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<GroupsCurators>(entity =>
            {
                entity.HasKey(gc => gc.Id);
                entity.Property(gc => gc.Id)
                      .ValueGeneratedOnAdd();

                entity.HasOne(gc => gc.Curator)
                      .WithMany(c => c.GroupsCurators)
                      .HasForeignKey(gc => gc.CuratorId)
                      .IsRequired();
                entity.HasOne(gc => gc.Group)
                      .WithMany(g => g.GroupsCurators)
                      .HasForeignKey(gc => gc.GroupId)
                      .IsRequired();
            });

            modelBuilder.Entity<GroupsLectures>(entity =>
            {
                entity.HasKey(gl => gl.Id);
                entity.Property(gl => gl.Id).ValueGeneratedOnAdd();

                entity.HasOne(gl => gl.Group)
                      .WithMany(g => g.GroupsLectures)
                      .HasForeignKey(gl => gl.GroupId)
                      .IsRequired();

                entity.HasOne(gl => gl.Lecture)
                      .WithMany(l => l.GroupsLectures)
                      .HasForeignKey(gl => gl.LectureId)
                      .IsRequired();
            });

            modelBuilder.Entity<GroupsStudents>(entity =>
            {
                entity.HasKey(gs => gs.Id);
                entity.Property(gs => gs.Id).ValueGeneratedOnAdd();

                entity.HasOne(gs => gs.Group)
                      .WithMany(g => g.GroupsStudents)
                      .HasForeignKey(gs => gs.GroupId)
                      .IsRequired();

                entity.HasOne(gs => gs.Student)
                      .WithMany(s => s.GroupsStudents)
                      .HasForeignKey(gs => gs.StudentId)
                      .IsRequired();
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
               
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(l => l.Date)
                      .IsRequired();
                entity.HasCheckConstraint("CK_Lecture_Date", "[Date] <= GETDATE()");

                entity.HasOne(l => l.Subject)
                      .WithMany(s => s.Lectures)
                      .HasForeignKey(l => l.SubjectId)
                      .IsRequired();

                entity.HasOne(l => l.Teacher)
                      .WithMany(t => t.Lectures)
                      .HasForeignKey(l => l.TeacherId)
                      .IsRequired();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd();

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

                entity.Property(s => s.Surname)
                      .IsRequired()
                     .HasColumnType("nvarchar(max)");

                entity.Property(s => s.Rating)
                      .IsRequired();
                entity.HasCheckConstraint("CK_Student_Rating", "[Rating] >= 0 AND [Rating] <= 5");

                entity.HasOne(s => s.Group)
                      .WithMany(g => g.Students)
                      .HasForeignKey(s => s.GroupId)
                      .IsRequired();
            });

            modelBuilder.Entity<SubJect>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(s => s.Name)
                      .IsUnique();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                // Первичный ключ
                entity.HasKey(t => t.Id);

                // Id — автоприрост
                entity.Property(t => t.Id)
                      .ValueGeneratedOnAdd();

                // IsProfessor — BIT, NOT NULL, default false
                entity.Property(t => t.isProfessor)
                      .IsRequired()
                      .HasDefaultValue(false);

                // Name — nvarchar(max), NOT NULL
                entity.Property(t => t.Name)
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

                // Surname — nvarchar(max), NOT NULL
                entity.Property(t => t.Surname)
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

                // Salary — int, NOT NULL, > 0
                entity.Property(t => t.Salary)
                      .IsRequired();
                entity.HasCheckConstraint("CK_Teacher_Salary", "[Salary] > 0");
            });




        }


    }
}
