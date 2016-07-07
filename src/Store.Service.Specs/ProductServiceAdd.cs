using Machine.Specifications;
using NSubstitute;

namespace Store.Service.Specs
{
  [Subject(typeof(ProductService))]
  public class ProductServiceAdd  : ProductServiceBaseSpecs
  {
    class when_product_added_to_store
    {
      Establish context = () =>
        _repository.Add(Arg.Any<Product>())
          .Returns(new Product { Id = 1, Name = "Product Name", Price = 1M });

      Because of = () => _newProduct = _productService.Add(new Product());

      It should_call_add_method_one_time = () => _repository.Received(1).Add(Arg.Any<Product>());
      It should_return_new_product = () => _newProduct.ShouldNotBeNull();
      It should_have_new_product_id = () => _newProduct.Id.ShouldEqual(1);

      static Product _newProduct;
    }
  }
}