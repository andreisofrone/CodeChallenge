using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations
{
    internal class AppliedAmountConfiguration
            : IEntityTypeConfiguration<AppliedAmount>
    {
        public void Configure(EntityTypeBuilder<AppliedAmount> builder)
        {
            builder.ToTable("TotalFutureDebts");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnType("bigint")
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(c => c.LowerBound)
                .HasColumnType("bigint")
                .HasColumnName("LowerBound")
                .IsRequired();

            builder
                .Property(c => c.UpperBound)
                .HasColumnType("bigint")
                .HasColumnName("UpperBound")
                .IsRequired();

            builder
                 .Property(c => c.Decision)
                 .HasColumnType("bit")
                 .HasColumnName("Decision")
                 .IsRequired();
        }
    }
}
