using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class ActivityConfig : IEntityTypeConfiguration<Domain.Activity>
    {
        public void Configure(EntityTypeBuilder<Domain.Activity> builder)
        {                            
            builder.Property(p => p.Title).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(max)");

        }
    }
}
