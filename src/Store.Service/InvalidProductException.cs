using System;

namespace Store.Service
{
  public class InvalidProductException : Exception
  {
    public InvalidProductException(string message) : base(message)
    {
    }
  }
}