using System;
using Microsoft.EntityFrameworkCore;
using TabuProject.Entities;

namespace TabuProject.DAL
{
	public class TabuDbContext : DbContext
	{
		public DbSet<Language> Languages{ get; set; }
		public TabuDbContext(DbContextOptions<TabuDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Language>(b =>
			{
				b.HasKey(x => x.Code);
				b.Property(x => x.Code)
					.IsFixedLength(true)
					.HasMaxLength(2); 
				b.HasIndex(x => x.Name)
					.IsUnique(); 
				b.Property(x => x.Name)
					.HasMaxLength(32)
					.IsRequired();
				b.Property(x => x.Icon)
					.HasMaxLength(128); 
					
			});
            base.OnModelCreating(modelBuilder);
        }
    }
}

