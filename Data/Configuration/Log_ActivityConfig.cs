using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class Log_ActivityConfig :IEntityTypeConfiguration<Domain.Log_Activity>
    {
        public void Configure(EntityTypeBuilder<Domain.Log_Activity> builder)
        {
            builder.Property(p => p.DateTime).HasColumnType("DateTime");   
            builder.HasOne(x=>x.Status).WithMany(x=>x.Logs).HasForeignKey(x=>x.StatusId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
