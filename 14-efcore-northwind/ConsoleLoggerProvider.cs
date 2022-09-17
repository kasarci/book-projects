using Microsoft.Extensions.Logging;

namespace _14_efcore_northwind;

public class ConsoleLoggerProvider : ILoggerProvider {
  public ILogger CreateLogger(string categoryName) {
    return new ConsoleLogger();
  }

  public void Dispose() { }
}