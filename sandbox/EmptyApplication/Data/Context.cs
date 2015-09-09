using Microsoft.Data.Entity;
using EmptyApplication.Models;

namespace EmptyApplication.Data
{
	public class DataEventRecordContext : DbContext
	{
		public DbSet<DataEventRecord> DataEventRecords { get; set; }
		
		public DataEventRecordContext()
		{
			Database.EnsureCreated();
		}
		
		protected override void OnModelCreating(ModelBuilder builder)
		{ 
			builder.Entity<DataEventRecord>().Key(m => m.Id); 
			base.OnModelCreating(builder); 
		} 
	}
}
