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
                .HasForeignKey(agency => agency.BankId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(bank => bank.Accounts)
                .WithOne(account => account.Bank)
                .HasForeignKey(account => account.BankId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(bank => bank.Code).HasDatabaseName("IX_Bank_Code");
            builder.HasIndex(bank => bank.Name).HasDatabaseName("IX_Bank_Name");
        }
    }
}