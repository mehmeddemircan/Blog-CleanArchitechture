using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs"); // Table name

            builder.HasKey(b => b.Id); // Primary key

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(b => b.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.ThumbNailImage)
                .HasColumnName("ThumbNailImage")
                .HasMaxLength(500);

            builder.Property(b => b.Content)
                .HasColumnName("Content")
                .IsRequired();

            builder.Property(b => b.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(b => b.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.HasOne(b => b.Category);
            builder.HasOne(b => b.User);


            // Add common properties if needed
            builder.Property(b => b.CreatedTime)
                .HasColumnName("CreatedTime")
                .IsRequired();

            builder.Property(b => b.UpdatedTime)
                .HasColumnName("UpdatedTime")
                .IsRequired(false);

            builder.Property(b => b.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            builder.Property(b => b.IsDeleted)
                .HasColumnName("IsDeleted")
                .IsRequired();
        }

    

    }
}
