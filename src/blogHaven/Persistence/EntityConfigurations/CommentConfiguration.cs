using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.ToTable("Comments"); // Table name

            builder.HasKey(b => b.Id); // Primary key

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(b => b.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.BlogId)
                .HasColumnName("BlogId")
                .IsRequired();

            builder.Property(b => b.UserId)
                .HasColumnName("UserId")
                .IsRequired();

         

            builder.HasOne(e => e.Blog)
               .WithMany(b => b.Comments)
               .HasForeignKey(e => e.BlogId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict to prevent cycles

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
