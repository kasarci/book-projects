Person person = new() {Name = "Ali", Age= 27, DateOfBirth= new DateTime(1995,1,1)};
// For deconstructing the type, we do not need to call Deconstruct method. 
// We just need to know how many fields our deconstructor returns in the tuple. 
var (a,b,c) = person;

Console.WriteLine($"{a} is {b} years old and his birthday is {c:dd MMMMM yy}");
//Output: Ali is 27 years old and his birthday is 01 January 95


public class Person {
  public string Name { get; set; }
  public byte Age { get; set; }
  public DateTime DateOfBirth { get; set; }

  //Deconstruct method helps our type to return the necessary fields as tuples.
  public void Deconstruct(out string name, out byte age, out DateTime dateOfBirth) {
    name = Name;
    age = Age;
    dateOfBirth = DateOfBirth;
  }
}