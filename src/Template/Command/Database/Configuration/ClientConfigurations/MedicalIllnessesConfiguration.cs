using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.ClientAggregate;

namespace Template.Command.Database.Configuration.ClientConfigurations
{
    internal class MedicalIllnessesConfiguration : IEntityTypeConfiguration<MedicalIllnesses>
    {
        public void Configure(EntityTypeBuilder<MedicalIllnesses> builder)
        {
            builder.ToTable("MedicalIllnessess");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}