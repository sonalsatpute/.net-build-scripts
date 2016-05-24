using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NSubstitute;

namespace Store.Service.Specs
{
  [Subject(typeof(ProductService))]
  public class ProductServiceSpecs
  {
    static IProductRepository _repository;
    static ProductService _productService;
    static IEnumerable<Product> _products;

    Establish context = () =>
    {
      _repository = Substitute.For<IProductRepository>();
      _productService = new ProductService(_repository);
    };

    static IEnumerable<Product> GetDummyProducts()
    {
      return new List<Product>()
      {
        new Product {Id=1,Name = "Product 1", Price = 10.00M},
        new Product {Id=2,Name = "Product 2", Price = 15.00M},
        new Product {Id=3,Name = "Product 3", Price = 18.00M},
        new Product {Id=4,Name = "Product 4", Price = 2.00M},
        new Product {Id=5,Name = "Product 5", Price = 3.00M},
        new Product {Id=6,Name = "Product 6", Price = 6.00M},
        new Product {Id=7,Name = "Product 7", Price = 9.00M},
        new Product {Id=8,Name = "Product 8", Price = 12.00M},
        new Product {Id=9,Name = "Product 9", Price = 50.00M},
        new Product {Id=10,Name = "Product 10", Price = 100.00M},
      };
    }

    class when_store_has_no_produts
    {
      Establish context = () => _repository.GetAll().Returns(new List<Product>());

      Because of = () => _products = _productService.GetAll();

      It should_return_zero_producrs = () => _products.Count().ShouldEqual(0);
    }

    class when_store_has_one_product
    {
      Establish context = () => _repository.GetAll().Returns(new List<Product>() { new Product() });

      Because of = () => _products = _productService.GetAll();

      It should_return_one_producrs = () => _products.Count().ShouldEqual(1);
    }

    class when_store_has_ten_products
    {
      Establish context = () => _repository.GetAll().Returns(GetDummyProducts());

      Because of = () => _products = _productService.GetAll();

      It should_return_one_producrs = () => _products.Count().ShouldEqual(10);
    }

    class when_store_has_no_product_with_id
    {
      Establish context = () =>
        _repository.Get(1).Returns(a => null);

      Because of = () => _product = _productService.Get(1);

      It should_return_null = () => _product.ShouldBeNull();
      static Product _product;
    }

    class when_store_has_product_with_id
    {
      Establish context = () =>
        _repository.Get(1)
          .Returns(
            new Product {Id = 1, Name = "Product Name", Price = 11.50M}
          );

      Because of = () => _product = _productService.Get(1);

      It should_return_product = () => _product.ShouldNotBeNull();
      It shoudl_have_id = () => _product.Id.ShouldEqual(1);
      It shoudl_have_name = () => _product.Name.ShouldEqual("Product Name");
      It shoudl_have_price = () => _product.Price.ShouldEqual(11.50M);

      static Product _product;
    }

    class when_adding_product_to_store
    {
      Establish context = () => 
      _repository.Add(Arg.Any<Product>())
      .Returns(new Product {Id = 1, Name = "Product Name", Price = 1M});

      Because of = () => _newProduct = _productService.Add(new Product());

      It should_call_add_method_one_time = () => _repository.Received(1).Add(Arg.Any<Product>());
      It should_return_new_product = () => _newProduct.ShouldNotBeNull();
      It should_have_new_product_id = () => _newProduct.Id.ShouldEqual(1);

      static Product _newProduct;
    }
  }
}
