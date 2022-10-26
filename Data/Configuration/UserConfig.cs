using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {

            builder.Property(p => p.FirstName).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.LastName).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.NationalCode).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.Mobile).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.UserName).HasColumnType("nvarchar(Max)");
            builder.Property(p => p.Password).HasColumnType("nvarchar(Max)");
      
        }
    }
}
