using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.RequestChangeAggregate;

namespace Template.Command.Database.Configuration.RequestChangeConfigurations
{
    public class RequestChangeConfiguration : IEntityTypeConfiguration<RequestChangeHistory>
    {
        public void Configure(EntityTypeBuilder<RequestChangeHistory> builder)
        {
            builder.ToTable("RequestChangeHistorys");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}