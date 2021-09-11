using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations
{
    internal class TotalFutureDebtConfigration
           : IEntityTypeConfiguration<TotalFutureDebt>
    {
        public void Configure(EntityTypeBuilder<TotalFutureDebt> builder)
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
                 .Property(c => c.InterestRate)
                 .HasColumnType("int")
                 .HasColumnName("InterestRate")
                 .IsRequired();
        }
    }
}
