﻿using Infrastructure.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ConfigConstants.DEFAULT_NAME_LENGTH);

            builder.Property(a => a.PluralsightUrl)
            .HasMaxLength(ConfigConstants.DEFAULT_URI_LENGTH);

            builder.Property(a => a.TwitterAlias)
                .HasMaxLength(ConfigConstants.DEFAULT_NAME_LENGTH);

            builder.HasData(SeedData.Authors());
        }
    }
}
