using System;
using System.Runtime.InteropServices.ComTypes;

public class PersonException : Exception
{
  public PersonException() : base()
  {
  }

  public PersonException(string message) : base(message)
  {
  }

  public PersonException(string message, Exception innerException) : base(message, innerException)
  {
  }
}