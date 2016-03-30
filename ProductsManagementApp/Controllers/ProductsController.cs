using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProductsManagementApp.Models;
using System.Net;

namespace ProductsManagementApp.Controllers
{
	public class ProductsController : ApiController
	{
		static readonly IProductRepository repository = new ProductRepository();

		/// <summary>
		/// Http Post request to create a new Product
		/// </summary>
		/// <param name="product">{ "Id":4, "Name":"Mix Fruit", "Category":"Food Drinks", "Price":10.99 }</param>
		/// <returns>Newly added product</returns>
		/// <remarks>http://localhost:55590/products</remarks>
		[HttpPost]
		[Route("products")]
		public IHttpActionResult AddProduct(Product product)
		{
			if (product == null)
			{
				//throw new HttpResponseException(HttpStatusCode.NotFound);
				return NotFound();
			}
			repository.Add(product);
			return Ok(product);
		}

		/// <summary>
		/// Http Get request
		/// </summary>
		/// <returns>The entire list of products as an IEnumerable<Product> type</returns>
		/// <remarks>http://localhost:55590/products</remarks>
		[HttpGet]
		[Route("products")]
		public ICollection<Product> GetAllProducts()
		{
			return repository.GetAllProducts();
		}

		/// <summary>
		/// Http Get request with the ID placeholder which is dynamic
		/// </summary>
		/// <param name="id">id=1</param>
		/// <returns>A single product by its ID</returns>
		/// <remarks>http://localhost:55590/products/1</remarks>
		[HttpGet]
		[Route("products/{id}")]
		public IHttpActionResult GetProductById(int id)
		{
			Product product = repository.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		/// <summary>
		/// Http Put request to update a product
		/// </summary>
		/// <param name="id"></param>
		/// <param name="product"></param>
		/// <returns></returns>
		/// <remarks>http://localhost:55590/products/1</remarks>
		[HttpPut]
		[Route("products/{id}")]
		public IHttpActionResult UpdateProduct(int id, Product product)
		{
			product.Id = id;
			if (!repository.Update(product))
			{
				return NotFound();
			}
			return Ok();
		}

		/// <summary>
		/// Http Delete request to remove a product
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <remarks>http://localhost:55590/products/1</remarks>
		/// <example></example>
		[HttpDelete]
		[Route("products/{id}")]
		public IHttpActionResult DeleteProduct(int id)
		{
			Product product = repository.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			repository.Remove(id);
			return Ok();
		}
	}
}
