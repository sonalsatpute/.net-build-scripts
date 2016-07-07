using System;
using Machine.Specifications;
using NSubstitute;

namespace StoreService.Specs
{
  [Subject(typeof(ProductService))]
  public class ProductServiceUpdate : ProductServiceBaseSpecs
  {
    class when_product_update_which_is_not_in_store
    {
      Establish context = () =>
        _repository.Update(Arg.Any<Product>())
          .Returns(ex => { throw new InvalidProductException("Product with Id '0' not presetn."); });

      Because of = () => _exception = Catch.Exception(() => _productService.Update(new Product()));

      It should_call_update_method_one_time = () => _repository.Received(1).Update(Arg.Any<Product>());
      It should_throw_invalid_product_exception = () => _exception.ShouldBeOfExactType<InvalidProductException>();
      It should_say_product_with_id_0_not_present = () => _exception.Message.ShouldContain("Product with Id '0' not presetn.");

      static Exception _exception;
    }

    class when_product_update_in_store
    {
      Establish context = () =>
        _repository.Update(Arg.Any<Product>())
          .Returns(p => new Product { Id = 1, Name = "Updated Name", Price = 1.99M });

      Because of = () => _product = _productService.Update(new Product { Id = 1, Name = "Product Name", Price = 0.99M });

      It should_call_update_method_one_time = () => _repository.Received(1).Update(Arg.Any<Product>());

      It should_not_update_product_id = () => _product.Id.ShouldEqual(1);
      It should_update_product_name = () => _product.Name.ShouldEqual("Updated Name");
      It should_update_product_price = () => _product.Price.ShouldEqual(1.99M);

      static Product _product;
    }
  }
}