using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.ClientAggregate;

namespace Template.Command.Database.Configuration.ClientConfigurations
{
    public class AddresHistoryConfiguration : IEntityTypeConfiguration<AddressHistory>
    {
        public void Configure(EntityTypeBuilder<AddressHistory> builder)
        {
            builder.ToTable("AddressHistorys");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}