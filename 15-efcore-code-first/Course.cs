using System.ComponentModel.DataAnnotations;

namespace _15_efcore_code_first;

public class Course {
  public int CourseID { get; set; }
  [Required]
  [StringLength(60)]
  public string Title { get; set; }
  public ICollection<Student> Students { get; set; }
}