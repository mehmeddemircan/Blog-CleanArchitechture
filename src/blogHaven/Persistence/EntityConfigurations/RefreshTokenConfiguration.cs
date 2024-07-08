using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Security.Entities;

namespace Persistence.EntityConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
          
                // Table name and primary key configuration
                builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);

                // Property configurations
                builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
                builder.Property(rt => rt.UserId).HasColumnName("UserId").IsRequired();
                builder.Property(rt => rt.Token).HasColumnName("Token").IsRequired().HasMaxLength(256);
                builder.Property(rt => rt.Expires).HasColumnName("Expires").IsRequired();
                builder.Property(rt => rt.Created).HasColumnName("Created").IsRequired();
                builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp").IsRequired().HasMaxLength(45);
                builder.Property(rt => rt.Revoked).HasColumnName("Revoked");
                builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp").HasMaxLength(45);
                builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken").HasMaxLength(256);
                builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked").HasMaxLength(256);

              
            
        }
     }
}
