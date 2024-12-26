using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabuProject.Entities;

namespace TabuProject.Configurations
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {
            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
