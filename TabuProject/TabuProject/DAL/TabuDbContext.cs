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
			modelBuilder.Entity<Word>(w =>
			{
				w.Property(x => x.Text)
					.IsRequired()
					.HasMaxLength(32);
				w.HasOne(x => x.Language)
					.WithMany(x => x.Words)
					.HasForeignKey(x => x.LangCode);
				w.HasMany(x => x.BannedWords)
					.WithOne(x => x.Word)
					.HasForeignKey(x => x.WordId);

			});
			modelBuilder.Entity<Game>(g =>
			{
				g.HasKey(x => x.Id);
				g.HasOne(x => x.Language)
					.WithMany(x => x.Games)
					.HasForeignKey(x => x.LangCode);
				g.Property(x => x.BannedWordCount)
					.IsRequired();
				g.Property(x => x.FailCount)
					.IsRequired();
				g.Property(x => x.SkipCount)
					.IsRequired();
				g.Property(x => x.SuccessAnswer)
					.IsRequired(); 

			});
			modelBuilder.Entity<BannedWord>(b =>
			{
				b.Property(x => x.Text)
					.IsRequired()
					.HasMaxLength(32);
						
			});
            base.OnModelCreating(modelBuilder);
        }
    }
}

