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
<<<<<<< HEAD
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabuDbContext).Assembly); 
=======
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabuDbContext).Assembly);
>>>>>>> e8b785d09ea60016d908cb50d1ca735cc7e2c669
            base.OnModelCreating(modelBuilder);
        }
    }
}

