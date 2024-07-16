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
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            // Set the table name
            builder.ToTable("Testimonials");

            // Configure the primary key
            builder.HasKey(t => t.Id);

            // Configure properties
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Feedback)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(t => t.Date)
                   .IsRequired();

            builder.Property(t => t.PhotoUrl)
                   .HasMaxLength(200)
                   .IsRequired(false); 
        }
    }
}
