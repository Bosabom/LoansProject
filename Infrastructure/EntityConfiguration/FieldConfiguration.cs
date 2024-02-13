using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasOne(s => s.Section)
                   .WithMany(f => f.Fields)
                   .HasForeignKey(k => k.SectionId);

            builder.Property(v => v._Validation).HasColumnName("Validation");

            builder.Property(v => v._Readonly).HasColumnName("Readonly");

            builder.Property(v => v._Calculated).HasColumnName("Calculated");

            builder.Property(v => v._Options).HasColumnName("Options");
        }
    }
}
