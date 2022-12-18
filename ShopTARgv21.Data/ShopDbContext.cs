using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using System.Collections.Generic;

namespace ShopTARgv21.Data
{
	public class ShopDbContext : DbContext
	{
		public ShopDbContext(DbContextOptions<ShopDbContext> options)
		: base(options) { }

		public DbSet<Spaceship> Spaceship { get; set; }

	}
}