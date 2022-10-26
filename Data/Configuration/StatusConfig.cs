using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;



namespace Data.Configuration
{
    public class StatusConfig : IEntityTypeConfiguration<Domain.Status>
    {
        public void Configure(EntityTypeBuilder<Domain.Status> builder)
        {
            builder.Property(p => p.Title).HasColumnType("nvarchar(Max)");
        } 
    }
}
