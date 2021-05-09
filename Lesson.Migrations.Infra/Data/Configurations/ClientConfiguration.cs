namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientConfiguration:IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(cli => cli.Id);
            builder.Property(cli => cli.Name).HasMaxLength(200).IsRequired();
            builder.Property(cli => cli.BirthDate).HasColumnType("DATETIME").IsRequired();

            builder.HasMany(cli => cli.Accounts)
                .WithOne(acl => acl.Client)
                .HasForeignKey(acl => acl.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(cli => cli.Document).HasDatabaseName("IX_Client_Document");
            builder.HasIndex(cli => cli.Name).HasDatabaseName("IX_Client_Name");
        }
    }
}