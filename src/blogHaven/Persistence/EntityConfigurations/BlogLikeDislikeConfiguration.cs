using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class BlogLikeDislikeConfiguration : IEntityTypeConfiguration<BlogLikeDislike>
    {
        public void Configure(EntityTypeBuilder<BlogLikeDislike> builder)
        {
            builder.ToTable("BlogLikeDislikes"); // Table name

            builder.HasKey(bld => bld.Id); // Primary key

            builder.Property(bld => bld.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(bld => bld.BlogId)
                .HasColumnName("BlogId")
                .IsRequired();

            builder.Property(bld => bld.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(bld => bld.ActionedOn)
                .HasColumnName("ActionedOn")
                .IsRequired();

            builder.Property(bld => bld.IsLiked)
                .HasColumnName("IsLiked")
                .IsRequired();

            builder.HasOne(b => b.User)
                              .WithMany()
                              .HasForeignKey(b => b.UserId)
                              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Blog)
                   .WithMany()
                   .HasForeignKey(b => b.BlogId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
