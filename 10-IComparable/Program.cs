using _10_IComparable;

Person[] people = {
  new () {Name = "Ali"},
  new () {Name = "Osman"},
  new () {Name = "Abdurrahim"},
  new () {Name = "Fatih"},
  new () {Name = "Bekir"}
};

System.Console.WriteLine("Before sorting...");
foreach( var person in people ) {
  Console.WriteLine(person.Name);
}

System.Console.WriteLine();
System.Console.WriteLine("After sorting...");

Array.Sort(people);
foreach( var person in people ) {
  Console.WriteLine(person.Name);
}

System.Console.WriteLine();
System.Console.WriteLine("After sorting by PersonComparer");

Array.Sort(people, new PersonComparer());
foreach( var person in people ) {
  Console.WriteLine(person.Name);
}


// we can use IComparable interface to make our Person class comparable.
class Person : object, IComparable<Person> {
  public string Name { get; set; }

  //IComparable implementation.
  public int CompareTo(Person? otherPerson) {
    if (otherPerson is null) 
      return 0;
    
    return Name.CompareTo(otherPerson.Name);
  }
}