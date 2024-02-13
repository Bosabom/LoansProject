using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasOne(l => l.LoanTemplate)
                   .WithMany(s => s.Sections)
                   .HasForeignKey(k => k.LoanTemplateId);
        }
    }
}
