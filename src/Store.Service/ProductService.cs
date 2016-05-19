using System.Collections.Generic;

namespace Store.Service
{
  public class ProductService
  {
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<Product> GetAll()
    {
      return _repository.GetAll();
    }
  }
}