using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NSubstitute;

namespace Store.Service.Specs
{
  [Subject("Product Service")]
  public class ProductServiceSpecs
  {
    public class when_there_is_no_produts_in_store
    {
      Establish context = () =>
      {
        _repository = Substitute.For<IProductRepository>();
        _repository.GetAll().Returns(new List<Product>());
        _productService = new ProductService(_repository);
      };

      Because of = () => _products = _productService.GetAll();

      It should_return_zero_producrs = () => _products.Count().ShouldEqual(0);

      static IProductRepository _repository;
      static ProductService _productService;
      static IEnumerable<Product> _products;
    }
  }
}
