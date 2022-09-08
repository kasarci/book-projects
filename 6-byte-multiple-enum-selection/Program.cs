/*
  Good Practice: Use the enum values to store combinations of discrete options.
  Derive an enum type from byte if there are up to eight options, from ushort
  if there are up to 16 options, from uint if there are up to 32 options, and from
  ulong if there are up to 64 options.
*/

Human human = new () {
  FavouriteColor = Colors.blue | Colors.green
};

Console.WriteLine($"This human's favourite color is {human.FavouriteColor}.");
//output: This human's favourite color is green, blue.

// System Flags attribute is helping us to return multiple values as comma seperated strings automatically.
[System.Flags]
public enum Colors : byte {
  /* Normally, an enum type uses an int variable internally, but since we don't need values
  that big, we can reduce memory requirements by 75%, that is, 1 byte per value instead
  of 4 bytes, by telling it to use a byte variable. */
  red = 0b_0000_0000,
  green = 0b_0000_0001,
  blue = 0b_0000_0010
}

public class Human {
  public Colors FavouriteColor { get; set; }
}
