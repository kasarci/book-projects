namespace _10_IComparable;

//Sometime we won't have access to the source code of the classes and might not implement the ICompareble interface
//Luckily, there is another way to sort instances. of a type. We can create a seperate type that implements different interface.
//IComparer
public class PersonComparer : IComparer<Person> {
  
  //Let's make a slightly different comparer this time.
  //First compare by the lengths and if the lengths are equal, then compare by the alphabetical order.
  int IComparer<Person>.Compare(Person? x, Person? y) {
    if (x is null || y is null ) 
      return 0;

    int result = x.Name.Length.CompareTo(y.Name.Length);

    //If the lengths are the same then compare by alphabetical order.
    if (result == 0) {
      result = x.Name.CompareTo(y.Name);
    }
    return result;
  }
}