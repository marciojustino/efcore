namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedAt).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.SignedAt).HasColumnName("DATETIME");

            builder.HasOne(c => c.Account)
                .WithOne(acc => acc.Contract)
                .HasForeignKey<Contract>(acc => acc.AccountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}