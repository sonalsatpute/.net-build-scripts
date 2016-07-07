using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NSubstitute;

namespace StoreService.Specs
{
  [Subject(typeof(ProductService))]
  public class Db_ProductServiceBaseGet : ProductServiceBaseSpecs
  {
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

      It should_return_ten_producrs = () => _products.Count().ShouldEqual(10);
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
            new Product { Id = 1, Name = "Product Name", Price = 11.50M }
          );

      Because of = () => _product = _productService.Get(1);

      It should_return_product = () => _product.ShouldNotBeNull();
      It shoudl_have_id = () => _product.Id.ShouldEqual(1);
      It shoudl_have_name = () => _product.Name.ShouldEqual("Product Name");
      It shoudl_have_price = () => _product.Price.ShouldEqual(11.50M);

      static Product _product;
    }
  }
}