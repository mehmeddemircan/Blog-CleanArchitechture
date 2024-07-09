using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.EntityConfigurations
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            // Table name and primary key configuration
            builder.ToTable("BlogTags").HasKey(uoc => uoc.Id);

            // Property configurations
            builder.Property(bt => bt.Id).HasColumnName("Id").IsRequired();
            builder.Property(bt => bt.TagId).HasColumnName("TagId").IsRequired();
            builder.Property(bt => bt.BlogId).HasColumnName("BlogId").IsRequired();

            // Relationship configurations
            builder.HasOne(uoc => uoc.Blog)
                   .WithMany(u => u.BlogTags)
                   .HasForeignKey(uoc => uoc.BlogId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uoc => uoc.Tag)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.TagId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
