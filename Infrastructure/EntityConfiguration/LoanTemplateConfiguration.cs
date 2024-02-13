using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class LoanTemplateConfiguration : IEntityTypeConfiguration<LoanTemplate>
    {
        public void Configure(EntityTypeBuilder<LoanTemplate> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
        }
    }
}
