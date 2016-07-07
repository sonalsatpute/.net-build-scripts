using System;

namespace StoreService
{
  public class InvalidProductException : Exception
  {
    public InvalidProductException(string message) : base(message)
    {
    }
  }
}