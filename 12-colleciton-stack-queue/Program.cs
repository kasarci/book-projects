using System.Collections.Generic;

WorkingWithDictionaries();
WorkingWithQueues();
WorkingWithStacks();

void WorkingWithDictionaries(){
  Console.WriteLine(" --- Working with Dictionaries! --- ");
  Dictionary<string, string> keywords = new()
  {
    { "int", "32-bit integer data type" },
    { "long", "64-bit integer data type" },
    { "float", "Single precision floating point number" }
  };

  PrintDictionary(keywords);
}

void WorkingWithQueues() {
  Console.WriteLine();
  Console.WriteLine(" --- Working with Queues! --- ");
  Queue<string> coffee = new ();
  
  coffee.Enqueue("Ali");
  coffee.Enqueue("Muhammet");
  coffee.Enqueue("Alex");
  coffee.Enqueue("Mauricio");
  coffee.Enqueue("Rico");
  
  Console.WriteLine();
  Console.WriteLine($"Initial queue from front to back. First come first serve...");
  PrintQueue(coffee);
  Console.WriteLine();

  Thread.Sleep(1000);
  Console.WriteLine($"{coffee.Dequeue()}'s coffee served.");
  Thread.Sleep(1000);
  Console.WriteLine($"{coffee.Dequeue()}'s coffee served.");
  Thread.Sleep(1000);
  Console.WriteLine($"{coffee.Dequeue()}'s coffee served.");
  Thread.Sleep(1000);

  Console.WriteLine();
  Console.WriteLine($"{coffee.Count} people left in the queue.");
  PrintQueue(coffee);
}

void WorkingWithStacks() {
  Stack<char> stack = new();
  int keyStrokeCount = 0;
  System.Console.WriteLine();
  Console.WriteLine("Type 10 characters.");
  while (keyStrokeCount < 10) {
    stack.Push(Console.ReadKey().KeyChar);
    keyStrokeCount++;
  }
  Thread.Sleep(1000);
  while (stack.Count != 0)
  {
    Console.Write("Ctrl + z => ");
    stack.Pop();
    PrintStack(stack);
    Thread.Sleep(250);
  }
}

void PrintDictionary<T>(Dictionary<T,T> dictionary) {
  foreach (var item in dictionary) {
    Console.WriteLine($"{item.Key}: {item.Value}");
  }
}

void PrintQueue<T>(Queue<T> queue) {
  foreach (var item in queue) {
    Console.WriteLine(item); 
}
}

void PrintStack<T>(Stack<T> stack) {
  for (int i = stack.Count - 1; i >= 0 ; i--)
  {
      Console.Write(stack.ElementAt(i));
  }
  Console.WriteLine();
}
