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
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            // Tablo adı
            builder.ToTable("FAQs");

            // Birincil anahtar
            builder.HasKey(f => f.Id);

            // Özellikler
            builder.Property(f => f.Question)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(f => f.Answer)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(f => f.QuestionPhoto)
                 .IsRequired(false)
                 .HasMaxLength(200);

            builder.Property(f => f.AnswerPhoto)
             .IsRequired(false)
             .HasMaxLength(200);

        }
    }
}
