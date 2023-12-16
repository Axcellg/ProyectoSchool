using Microsoft.EntityFrameworkCore;
using PruebaProgramacion.Models;

namespace PruebaProgramacion.Context;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }

    public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }

    public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<ViewCourse> ViewCourses { get; set; }

    public virtual DbSet<ViewInstructor> ViewInstructors { get; set; }

    public virtual DbSet<ViewStudent> ViewStudents { get; set; }

    public virtual DbSet<ViewStudentDetail> ViewStudentDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=School;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_School.Course");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Department");

            entity.HasMany(d => d.People).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseInstructor",
                    r => r.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CourseInstructor_Person"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CourseInstructor_Course"),
                    j =>
                    {
                        j.HasKey("CourseId", "PersonId");
                        j.ToTable("CourseInstructor");
                    });
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<OfficeAssignment>(entity =>
        {
            entity.Property(e => e.InstructorId).ValueGeneratedNever();
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Instructor).WithOne(p => p.OfficeAssignment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfficeAssignment_Person");
        });

        modelBuilder.Entity<OnlineCourse>(entity =>
        {
            entity.Property(e => e.CourseId).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithOne(p => p.OnlineCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OnlineCourse_Course");
        });

        modelBuilder.Entity<OnsiteCourse>(entity =>
        {
            entity.Property(e => e.CourseId).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithOne(p => p.OnsiteCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OnsiteCourse_Course");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_School.Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany(p => p.StudentGrades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentGrade_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGrades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentGrade_Student");
        });

        modelBuilder.Entity<ViewCourse>(entity =>
        {
            entity.ToView("ViewCourses");
        });

        modelBuilder.Entity<ViewInstructor>(entity =>
        {
            entity.ToView("ViewInstructors");
        });

        modelBuilder.Entity<ViewStudent>(entity =>
        {
            entity.ToView("ViewStudents");
        });

        modelBuilder.Entity<ViewStudentDetail>(entity =>
        {
            entity.ToView("ViewStudentDetail");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
