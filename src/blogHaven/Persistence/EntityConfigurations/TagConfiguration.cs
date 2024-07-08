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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId").IsRequired();
            //builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            //builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            //builder.HasIndex(indexExpression: b => b.Name, name: "UK_Brands_Name").IsUnique();
            //builder.HasMany(b => b.Models);

            //builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

    }
}