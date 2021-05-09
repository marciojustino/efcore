namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Number).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Status).HasConversion<string>().HasDefaultValue("Opened").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.OpenedAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnType("DATETIME");
            builder.HasIndex(i => i.Number).HasDatabaseName("idx_account_number");

            builder.HasOne(a => a.Agency)
                .WithMany(a => a.Accounts)
                .HasForeignKey(account => account.AgencyId);

            builder.HasOne(a => a.Bank)
                .WithMany(b => b.Accounts)
                .HasForeignKey(account => account.BankId);

            builder.HasMany(a => a.Owners)
                .WithOne(acl => acl.Account)
                .HasForeignKey(acl => acl.AccountId);

            builder.HasIndex(acc => acc.Number).HasDatabaseName("idx_account_number");
        }
    }
}