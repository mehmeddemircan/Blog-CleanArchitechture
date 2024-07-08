using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Security.Entities;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            // Table name and primary key configuration
            builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

            // Property configurations
            builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            // Relationship configurations
            builder.HasOne(uoc => uoc.User)
                   .WithMany(u => u.UserOperationClaims)
                   .HasForeignKey(uoc => uoc.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uoc => uoc.OperationClaim)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.OperationClaimId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
