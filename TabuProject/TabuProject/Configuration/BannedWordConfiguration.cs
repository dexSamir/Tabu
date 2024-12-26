using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabuProject.Entities;

namespace TabuProject.Configuration
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

