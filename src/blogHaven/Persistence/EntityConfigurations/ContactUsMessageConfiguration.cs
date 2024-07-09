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
    public class ContactUsMessageConfiguration : IEntityTypeConfiguration<ContactUsMessage>
    {
        public void Configure(EntityTypeBuilder<ContactUsMessage> builder)
        {
            builder.ToTable("ContactUsMessages").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Topic).HasColumnName("Topc").IsRequired();
            builder.Property(b => b.Content).HasColumnName("Content").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired(false);
            
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
