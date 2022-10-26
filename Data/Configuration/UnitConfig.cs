using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class UnitConfig: IEntityTypeConfiguration<Domain.Unit>
    {
        public void Configure(EntityTypeBuilder<Domain.Unit> builder)
        {
            builder.Property(p => p.title).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(Max)");         
        }
    }
}
