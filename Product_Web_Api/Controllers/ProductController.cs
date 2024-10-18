using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Web_Api.Core;

namespace Product_Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private static List<ProductEntity> products = new List<ProductEntity>{
				  new ProductEntity {Id=1,Name="Cep Telefonu" , Price="20000"},
				  new ProductEntity {Id=2,Name="Bilgisayar" , Price="50000"},
				  new ProductEntity {Id=3,Name="PowerBank" , Price="1000"},

			};
[HttpGet]
		public async  Task< IActionResult> Get()
		{
			return Ok(products);
		}
		//[HttpGet("{id}")] 
		//public async Task<IActionResult>Get(int id)
		
	}
}

