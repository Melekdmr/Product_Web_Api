using Product_Web_Api.Core;


namespace Product_Web_Api.Data
{
	public class Datacontext:DbContext
	{
		public Datacontext(DbContextOptions<Datacontext> options) : base(options) { }

		public DbSet<ProductEntity> productEntities { get; set; }
	}

} 
