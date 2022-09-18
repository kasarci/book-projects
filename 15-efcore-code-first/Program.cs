using _15_efcore_code_first;
using Microsoft.EntityFrameworkCore;

using ( Academy db = new ()) {
  bool deleted = await db.Database.EnsureDeletedAsync();
  Console.WriteLine($"Database deleted: {deleted}");

  bool created = await db.Database.EnsureCreatedAsync();
  Console.WriteLine($"Database created: {created}");

  Console.WriteLine("SQL script used to create database: ");
  Console.WriteLine(db.Database.GenerateCreateScript());

  foreach (var student in db.Students.Include(s => s.Courses)) {
    Console.WriteLine("{0} {1} attends the following {2} courses: ", 
                      student.FirstName, student.LastName, student.Courses.Count);
    foreach (var course in student.Courses) {
      Console.WriteLine($"    - {course.Title}");
    }
  }
}