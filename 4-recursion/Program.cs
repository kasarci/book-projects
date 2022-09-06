// calculating factorials.
RunFactorial();

int Factorial(int number) {
  if(number < 1) 
    return 0;
  else if(number == 1)
    return 1;
  else {
    checked
    {
      return number * Factorial(number - 1);
    }
  }
}

void RunFactorial() {
  for(int i = 0; i < 15; i++) {
    try
    {
      Console.WriteLine($"{i}! = {Factorial(i):N0}");
    }
    catch (OverflowException ex)
    {
      Console.WriteLine($"{i}! is too big for 32-bit integer.");
      Console.WriteLine($"{ex.GetType()}: {ex.Message}");
    }
  }
}