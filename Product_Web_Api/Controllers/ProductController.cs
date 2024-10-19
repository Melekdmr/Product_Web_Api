using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Web_Api.Core;

namespace Product_Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase /*ASP.NET Core API'sinin temel işlevselliğini sağlar. 
	                                                  API controller'larının View döndürmesine gerek 
	                                                 olmadığı için Controller yerine ControllerBase
	                                                 kullanılır. */


	{
		private static List<ProductEntity> products = new List<ProductEntity>{
				  new ProductEntity {Id=1,Name="Cep Telefonu" , Price="20000"},
				  new ProductEntity {Id=2,Name="Bilgisayar" , Price="50000"},
				  new ProductEntity {Id=3,Name="PowerBank" , Price="1000"},

			};
		[HttpGet]
		public async Task<ActionResult<List<ProductEntity>>> Get()
		{
			return Ok(products);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductEntity>> Get(int id)
		{
			var product = products.Find(x => x.Id == id);
			if (product == null)
			{
				return BadRequest("Ürün id'si bulunamadı");
			}
			return Ok(product);
		}
		// POST: Yeni bir ürün ekler
		[HttpPost]
		public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)
		{

			products.Add(product);
			return Ok(products);//sadece eklediğimiz product değil bütün listeyi dönmesi gereki o yüzden "products"
		}
		[HttpPut]
		public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity request)
		{
			var product = products.Find(x => x.Id ==request.Id);
			if (product == null)
			{
				return BadRequest("Bu id ile değiştirilecek ürün bulunamadı.");
			}
			product.Name = request.Name;
			product.Price = request.Price;
			return Ok(products);

		}
		[HttpDelete]
		public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
		{
			var product = products.Find(x => x.Id == id);
			if (product == null)
				return NotFound("Ürün Bulunamadı");

			products.Remove(product);
			return Ok(products);
		}
	}

}


