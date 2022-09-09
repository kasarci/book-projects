using System.Diagnostics.Contracts;
using static System.Console;

// Fields of tuples has got their names automatically as Item1, Item2... when they are leaved empty.
WriteLine($"I have {GetFruits().Item2} {GetFruits().Item1}.");
//Output: I have 3 apples.

WriteLine($"I also have {GetFruitsWithFieldNames().Count} {GetFruitsWithFieldNames().Name}.");
//Output: I also have 5 oranges.

//simple method returning (string, int) tuple
(string, int) GetFruits() {
  return ("apples", 3);
}

// Naming tuples.
(string Name, int Count) GetFruitsWithFieldNames () {
  return ("oranges", 5);
}
