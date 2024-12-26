using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabuProject.Entities;

namespace TabuProject.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.LangCode);
            builder.Property(x => x.BannedWordCount)
                .IsRequired();
            builder.Property(x => x.FailCount)
                .IsRequired();
            builder.Property(x => x.SkipCount)
                .IsRequired();
            builder.Property(x => x.Second)
                .IsRequired();
        }
    }
}
