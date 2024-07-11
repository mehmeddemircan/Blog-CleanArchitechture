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
    public class BlogFavoriteConfiguration : IEntityTypeConfiguration<BlogFavorite>
    {
        public void Configure(EntityTypeBuilder<BlogFavorite> builder)
        {
            builder.ToTable("BlogFavorites"); // Table name

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

            builder.Property(bld => bld.IsFavorite)
                .HasColumnName("IsFavorite")
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
