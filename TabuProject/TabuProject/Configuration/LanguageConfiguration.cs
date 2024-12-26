using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabuProject.Entities;

namespace TabuProject.Configuration
{
	public class LanguageConfiguration : IEntityTypeConfiguration<Language>
	{
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.Icon)
                .HasMaxLength(128);

        }
    }
}

