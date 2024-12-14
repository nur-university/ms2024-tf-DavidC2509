using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.ClientAggregate;

namespace Template.Command.Database.Configuration.ClientConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder
        .HasMany(e => e.Addresses)
        .WithOne()
        .IsRequired();

            builder
            .HasMany(e => e.MedicalIllnessess)
            .WithOne()
            .IsRequired();

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}