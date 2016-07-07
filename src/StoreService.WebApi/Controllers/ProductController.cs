using System.Collections.Generic;
using System.Web.Http;

namespace StoreService.WebApi.Controllers
{
  public class ProductController : ApiController
  {
    readonly ProductService _service;

    public ProductController(ProductService service)
    {
      _service = service;
    }

    public IHttpActionResult Get()
    {
      IEnumerable<Product> products = _service.GetAll();
      return Ok(products);
    }

    public IHttpActionResult Add(Product newProduct)
    {
      Product product = _service.Add(newProduct);
      return Ok(product);
    }
  }
}
