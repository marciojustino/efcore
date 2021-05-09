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
            builder.HasKey(acl => new {acl.AccountId, acl.ClientId});

            builder.HasOne(acl => acl.Account)
                .WithMany(aco => aco.Owners)
                .HasForeignKey(acl => acl.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(acl => acl.Client)
                .WithMany(cli => cli.Accounts)
                .HasForeignKey(acl => acl.ClientId);
        }
    }
}