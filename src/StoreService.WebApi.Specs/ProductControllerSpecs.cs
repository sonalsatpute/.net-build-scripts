using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Machine.Specifications;
using NSubstitute;
using StoreService.WebApi.Controllers;

namespace StoreService.WebApi.Specs
{
  [Subject(typeof(ProductController))]
  public class ProductControllerSpecs
  {
     static ProductController _productController;
     static IHttpActionResult _actionResult;


    static IEnumerable<Product> GetDummyProducts()
    {
      return new List<Product>()
        {
          new Product {Id = 1, Name = "Product 1", Price = 10.00M},
          new Product {Id = 2, Name = "Product 2", Price = 15.00M},
          new Product {Id = 3, Name = "Product 3", Price = 18.00M},
          new Product {Id = 4, Name = "Product 4", Price = 2.00M},
          new Product {Id = 5, Name = "Product 5", Price = 3.00M},
          new Product {Id = 6, Name = "Product 6", Price = 6.00M},
          new Product {Id = 7, Name = "Product 7", Price = 9.00M},
          new Product {Id = 8, Name = "Product 8", Price = 12.00M},
          new Product {Id = 9, Name = "Product 9", Price = 50.00M},
          new Product {Id = 10, Name = "Product 10", Price = 100.00M},
        };
    }

    
    class given_store_has_ten_products_when_requesting_all_products
    {
      Establish context = () =>
      {
        IProductRepository _repository = Substitute.For<IProductRepository>();
        _repository.GetAll().Returns(GetDummyProducts());
        _productController = new ProductController(new ProductService(_repository));
      };

      Because of = () => _actionResult = _productController.Get();

      It should_return_ok = () => _actionResult.ShouldBeOfExactType<OkNegotiatedContentResult<IEnumerable<Product>>>();
      It should_have_ten_products = () =>
      {
        var contentResult = _actionResult as OkNegotiatedContentResult<IEnumerable<Product>>;
        contentResult.Content.Count().ShouldEqual(10);
      };

     
      
    }

    class give_store_has_no_products_when_adding_new_product
    {
      Establish context = () =>
      {
        IProductRepository _repository = Substitute.For<IProductRepository>();
        _repository.Add(Arg.Any<Product>())
          .Returns(new Product { Id = 1, Name = "Product Name", Price = 1M });
        _productController = new ProductController(new ProductService(_repository));
        _product = new Product() { Name = "Product Name", Price = 10.0M };
      };

      Because of = () => _actionResult = _productController.Add(_product);

      It should_return_ok = () => _actionResult.ShouldBeOfExactType<OkNegotiatedContentResult<Product>>();

      It should_return_new_product = () =>
      {
        var contentResult = _actionResult as OkNegotiatedContentResult<Product>;
        contentResult.Content.ShouldNotBeNull();
        contentResult.Content.Id.ShouldEqual(1);
      };

      static Product _product;
    }
  }
}