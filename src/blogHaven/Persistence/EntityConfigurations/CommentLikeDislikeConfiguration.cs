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
    public class CommentLikeDislikeConfiguration : IEntityTypeConfiguration<CommentLikeDislike>
    {
        public void Configure(EntityTypeBuilder<CommentLikeDislike> builder)
        {
            builder.ToTable("CommentLikeDislikes"); // Table name

            builder.HasKey(bld => bld.Id); // Primary key

            builder.Property(bld => bld.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(bld => bld.CommentId)
                .HasColumnName("CommentId")
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

            builder.HasOne(b => b.Comment)
                   .WithMany()
                   .HasForeignKey(b => b.CommentId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
