using Microsoft.EntityFrameworkCore;

namespace _15_efcore_code_first;

class Academy : DbContext {
  public DbSet<Student>? Students { get; set; }
  public DbSet<Course>? Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

    string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");
    optionsBuilder.UseSqlite($"Filename={path}");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Student>().Property(s => s.LastName)
                                  .HasMaxLength(50)
                                  .IsRequired();
    Student[] students = new Student[] {
      new Student {
        StudentId = 1,
        FirstName = "Muhammet",
        LastName= "Kasarci"},
      new Student {
      StudentId = 2,
      FirstName = "Sura",
      LastName= "Kasarci"},
      new Student {
      StudentId = 3,
      FirstName = "Furkan",
      LastName= "Kasarci"}
    };

    Course[] courses = new Course[] {
      new Course {
        CourseID = 1,
        Title = "C# and .NET 10"
      },
      new Course {
        CourseID = 2,
        Title = "Object Oriented Programming"
      },
      new Course {
        CourseID = 3,
        Title = "Web Design"
      },
    };

    modelBuilder.Entity<Student>().HasData(students);

    modelBuilder.Entity<Course>().HasData(courses);

    modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(e => e.HasData(
                  new {CoursesCourseID = 1, StudentsStudentId = 1},
                  new {CoursesCourseID = 1, StudentsStudentId = 2},
                  new {CoursesCourseID = 1, StudentsStudentId = 3},
                  new {CoursesCourseID = 2, StudentsStudentId = 2},
                  new {CoursesCourseID = 3, StudentsStudentId = 3}
                ));
  }
}