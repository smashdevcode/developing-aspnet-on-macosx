using Microsoft.Data.Entity;
using EmptyApplication.Models;

namespace EmptyApplication.Data
{
	public class Context : DbContext
	{
		public DbSet<Record> Records { get; set; }

		public Context()
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Record>().Key(m => m.Id);
			base.OnModelCreating(builder);
		}
	}
}
