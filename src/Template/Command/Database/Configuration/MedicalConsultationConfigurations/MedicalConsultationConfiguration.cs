using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.MedicalConsultationAggregate;

namespace Template.Command.Database.Configuration.MedicalConsultationConfigurations
{
    public class MedicalConsultationConfiguration : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.ToTable("Consultations");

            builder
            .HasMany(e => e.HistoryConsultations)
            .WithOne()
            .IsRequired();

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}