namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Bank");
            builder.HasKey(bank => bank.Id);
            builder.Property(bank => bank.Code).HasMaxLength(4).IsRequired();
            builder.Property(bank => bank.Name).HasMaxLength(200).IsRequired();

            builder.HasMany(bank => bank.Agencies)
                .WithOne(agency => agency.Bank)
                .HasForeignKey(agency => agency.BankId);

            builder.HasMany(bank => bank.Accounts)
                .WithOne(account => account.Bank)
                .HasForeignKey(account => account.BankId);

            builder.HasIndex(bank => bank.Code).HasDatabaseName("idx_bank_code");
            builder.HasIndex(bank => bank.Name).HasDatabaseName("idx_bank_name");
        }
    }
}