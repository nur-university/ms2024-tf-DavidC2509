using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.ClientAggregate;
using Template.Domain.ValueObjects;

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

            var converter = new ValueConverter<EmailValueObject, string>(
                 costValue => costValue.Value, // CostValue to string
                 cost => new EmailValueObject(cost) // string to CostValue
             );

            builder.Property(x => x.Email)
                .HasConversion(converter);
        }
    }
}