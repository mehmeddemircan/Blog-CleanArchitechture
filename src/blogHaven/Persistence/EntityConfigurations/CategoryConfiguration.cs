﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.HasMany(b => b.Tags);
        //builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        //builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        //builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasIndex(indexExpression: b => b.Name, name: "UK_Brands_Name").IsUnique();

    }
}