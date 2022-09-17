using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;

namespace _14_efcore_northwind;

public class ConsoleLogger : ILogger
{
  public IDisposable BeginScope<TState>(TState state)
  {
    return null;
  }

  public bool IsEnabled(LogLevel logLevel)
  {
    switch (logLevel) {
      case LogLevel.Trace:
      case LogLevel.Information:
      case LogLevel.None:
        return false;
      case LogLevel.Critical:
      case LogLevel.Debug:
      case LogLevel.Error:
      case LogLevel.Warning:
      default:
        return true;
    };
  }

  public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
  {
    if (eventId.Id is 10806) {
      return;
    }
    
    Console.Write($"Level: {logLevel}, EventId: {eventId.Id}");

    if (state is not null) {
      Console.Write($", State: {state}");
    }

    if (exception is not null) {
      Console.Write($", Exception: {exception}");
    }

    Console.WriteLine();
  }
}