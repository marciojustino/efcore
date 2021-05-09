namespace Lesson.Migrations.Infra.Data.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AgencyConfiguration: IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.ToTable("Agency");
            builder.HasKey(agency => agency.Id);
            builder.Property(agency => agency.Code).HasMaxLength(4).IsRequired();
            builder.Property(agency => agency.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(agency => agency.Bank)
                .WithMany(bank => bank.Agencies)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(agency => agency.Accounts)
                .WithOne(account => account.Agency)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(agency => agency.Code).HasDatabaseName("idx_agency_code");
            builder.HasIndex(agency => agency.Name).HasDatabaseName("idx_agency_name");
        }
    }
}