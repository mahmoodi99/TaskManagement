using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Domain.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Role> builder)
        {
            builder.Property(p => p.Title).HasColumnType("nvarchar(Max)");
        }
    }
}
