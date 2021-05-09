namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AccountClientConfiguration: IEntityTypeConfiguration<AccountClient>
    {
        public void Configure(EntityTypeBuilder<AccountClient> builder)
        {
            builder.ToTable("AccountClient");
            builder.HasKey(acl => acl.Id);

            builder.HasOne(acl => acl.Account)
                .WithMany(aco => aco.Owners)
                .HasForeignKey(acl => acl.AccountId);

            builder.HasOne(acl => acl.Client)
                .WithMany(cli => cli.Accounts)
                .HasForeignKey(acl => acl.ClientId);
        }
    }
}