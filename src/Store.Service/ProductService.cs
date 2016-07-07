using System.Collections.Generic;

namespace StoreService
{
  public class ProductService
  {
    readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<Product> GetAll()
    {
      return _repository.GetAll();
    }

    public Product Get(int productId)
    {
      return _repository.Get(productId);
    }

    public Product Add(Product product)
    {
      return _repository.Add(product);
    }

    public Product Update(Product product)
    {
      return _repository.Update(product);
    }
  }
}