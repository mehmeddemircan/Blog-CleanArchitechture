﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name and primary key configuration
            builder.ToTable("Users").HasKey(u => u.Id);

            // Property configurations
            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").IsRequired();
            builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();

          
        }
       
    }
}
