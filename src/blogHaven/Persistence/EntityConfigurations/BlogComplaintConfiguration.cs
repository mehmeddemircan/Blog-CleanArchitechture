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
    public class BlogComplaintConfiguration : IEntityTypeConfiguration<BlogComplaint>
    {
        public void Configure(EntityTypeBuilder<BlogComplaint> builder)
        {
            builder.ToTable("BlogComplaints").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Message).HasColumnName("Message").IsRequired();
            builder.Property(b => b.BlogId).HasColumnName("BlogId").IsRequired();
            builder.Property(b => b.ComplainerId).HasColumnName("ComplainerId").IsRequired();

          
            builder.HasOne(b => b.Complainer)
                   .WithMany() 
                   .HasForeignKey(b => b.ComplainerId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(b => b.Blog)
                   .WithMany() 
                   .HasForeignKey(b => b.BlogId)
                   .OnDelete(DeleteBehavior.Restrict);

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
