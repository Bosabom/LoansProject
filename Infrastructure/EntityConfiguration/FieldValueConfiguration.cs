using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class FieldValueConfiguration : IEntityTypeConfiguration<FieldValue>
    {
        public void Configure(EntityTypeBuilder<FieldValue> builder)
        {
            builder.HasOne(l => l.Loan)
                   .WithMany(f => f.FieldValues)
                   .HasForeignKey(k => k.LoanId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.Field)
                   .WithMany(v => v.FieldValues)
                   .HasForeignKey(k => k.FieldId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
