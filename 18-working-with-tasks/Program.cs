using System.Diagnostics;
using System.Threading;
using static System.Console;

OutputThreadInfo();
Stopwatch stopwatch = Stopwatch.StartNew();

//Syncronous
// WriteLine("Running methods synchronously on the thread.");
// MethodA();
// MethodB();
// MethodC();

//Asyncronous
// WriteLine("Running methods asynchronously on multiple threads...");
// Task taskA = new(MethodA);
// taskA.Start();

// Task taskB = Task.Factory.StartNew(MethodB);

// Task TaskC = Task.Run(MethodC);

// Task[] tasks = {taskA, taskB, TaskC};
// Task.WaitAll(tasks);

WriteLine("Passing the resut of one task as an input into another.");

Task<string> taskServiceTehnSProc = Task.Factory
                                        .StartNew(CallWebService)
                                        .ContinueWith(previousTask => CallStoreProcedure(previousTask.Result));

WriteLine($"Task Result : {taskServiceTehnSProc.Result}");
WriteLine($"Task is completed succesfully? : {taskServiceTehnSProc.IsCompletedSuccessfully}");

WriteLine($"{stopwatch.ElapsedMilliseconds:#,##0}ms elapsed");

static Decimal CallWebService() {
  WriteLine("Starting call to web sevice...");
  OutputThreadInfo();
  Thread.Sleep(new Random().Next(2000,4000));
  WriteLine("Finished call to web service.");
  return 89.99M;
}

static string CallStoreProcedure(decimal amount) {
  WriteLine("Starting call to stored procedure...");
  OutputThreadInfo();
  Thread.Sleep(new Random().Next(2000,4000));
  WriteLine("Finished call to stored procedure.");
  return $"123 products cost more than {amount}";
}

static void OutputThreadInfo() {

  Thread thread = Thread.CurrentThread;

  WriteLine("Thread ID: {0}, Priority: {1}, BAckground: {2}, Name: {3}",
            thread.ManagedThreadId,
            thread.Priority,
            thread.IsBackground,
            thread.Name);
}

static void MethodA() {
  WriteLine("starting method A...");
  OutputThreadInfo();
  Thread.Sleep(3000);
  WriteLine("Finished method A.");
}


static void MethodB() {
  WriteLine("starting method B...");
  OutputThreadInfo();
  Thread.Sleep(2000);
  WriteLine("Finished method B.");
}


static void MethodC() {
  WriteLine("starting method C...");
  OutputThreadInfo();
  Thread.Sleep(1000);
  WriteLine("Finished method C.");
}