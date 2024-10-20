using Azure.Core;
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
		private readonly Datacontext _context;
		public ProductController(Datacontext context)
		{
			_context = context;
		}

	
		[HttpGet]
		public async Task<ActionResult<List<ProductEntity>>> Get()
		{
			return Ok(await _context.productEntities.ToListAsync());
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductEntity>> Get(int id)
		{
			var product = await _context.productEntities.FindAsync(id);
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
			_context.productEntities.Add(product);
			await _context.SaveChangesAsync();
			return Ok(await _context.productEntities.ToListAsync());//sadece eklediğimiz product değil bütün listeyi dönmesi gereki o yüzden "products"
		}
		[HttpPut]
		public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity request)
		{
			var product = await _context.productEntities.FindAsync(request.Id);
			if (product == null)
			{
				return BadRequest("Bu id ile değiştirilecek ürün bulunamadı.");
			}
			product.Name = request.Name;
			product.Price = request.Price;
			await _context.SaveChangesAsync();
			return Ok(await _context.productEntities.ToListAsync());

		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
		{
			var product = await _context.productEntities.FindAsync(id);
			if (product == null)
				return NotFound("Ürün Bulunamadı");
			_context.productEntities.Remove(product);
			await _context.SaveChangesAsync();
			return Ok(await _context.productEntities.ToListAsync());
		}
	}

}


