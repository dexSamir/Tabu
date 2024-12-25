using System;
using Microsoft.EntityFrameworkCore;
using TabuProject.Entities;

namespace TabuProject.DAL
{
	public class TabuDbContext : DbContext
	{
		public DbSet<Language> Languages{ get; set; }
		public DbSet<Word> Words{ get; set; }
		public DbSet<BannedWord> BannedWords { get; set; }
		public DbSet<Game> Games { get; set; }
		public TabuDbContext(DbContextOptions<TabuDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

