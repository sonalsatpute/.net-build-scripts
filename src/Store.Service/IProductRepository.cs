using System.Collections.Generic;

namespace StoreService
{
  public interface IProductRepository
  {
    Product Get(int id);
    IEnumerable<Product> GetAll();
    Product Add(Product product);
    Product Update(Product product);
  }
}