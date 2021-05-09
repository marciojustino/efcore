namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ValueObjects;

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Number).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Status).HasConversion<string>().HasDefaultValue(StatusAccount.Active).ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.OpenedAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne(a => a.Agency)
                .WithMany(a => a.Accounts)
                .HasForeignKey(account => account.AgencyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Bank)
                .WithMany(b => b.Accounts)
                .HasForeignKey(account => account.BankId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Owners)
                .WithOne(acl => acl.Account)
                .HasForeignKey(acl => acl.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(acc => acc.Contract)
                .WithOne(contract => contract.Account)
                .HasForeignKey<Account>(acc => acc.ContractId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(i => i.Number).HasDatabaseName("IX_Account_Number");
            builder.HasIndex(acc => acc.Number).HasDatabaseName("IX_Account_Number");
        }
    }
}