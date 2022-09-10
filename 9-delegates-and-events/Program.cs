using System;

Person Ali = new();
Ali.Shout += Ali_Shout;


for (int i = 0; i < 5; i++)
{
  Ali.Poke();
}

void Ali_Shout(object? sender, EventArgs e) {
  if (sender is null) return;

  Person p = (Person) sender;
  System.Console.WriteLine($"{p} is so angry now.");
}

class Person {
  public event EventHandler? Shout;
  public int AngerLevel;

  public void Poke() {
    AngerLevel++;
    
    if (AngerLevel > 3) {
      if ( Shout is not null ) { //If something is listening.
        Shout(this, EventArgs.Empty);
      }
      // Or after C# 6.0 we can use the following code for null checks.
      // Shout?.Invoke(this, EventArgs.Empty);
    }
  }
}

