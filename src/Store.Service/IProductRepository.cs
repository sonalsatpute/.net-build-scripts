using System.Collections.Generic;

namespace Store.Service
{
  public interface IProductRepository
  {
    Product Get(int id);
    IEnumerable<Product> GetAll();
  }
}