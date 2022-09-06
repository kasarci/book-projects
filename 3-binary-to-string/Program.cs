using System;
using System.Text;

byte[] byteArray = new byte[128];

new Random().NextBytes(byteArray); // NextBytes method fills the elements of a specified array of bytes with random numbers.

Console.WriteLine("Binary object as bytes: ");

for(int i  = 0; i < byteArray.Length; i++) {
  Console.Write($"{byteArray[i]:X} ");
}
Console.WriteLine();

string encoded = Convert.ToBase64String(byteArray);

Console.WriteLine(encoded);

var decodedCharArray = Convert.FromBase64String(encoded);

for (int i = 0; i < decodedCharArray.Length; i++)
{
  Console.Write($"{decodedCharArray[i]:X} ");
}