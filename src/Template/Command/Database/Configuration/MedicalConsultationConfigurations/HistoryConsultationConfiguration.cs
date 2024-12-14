using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.MedicalConsultationAggregate;

namespace Template.Command.Database.Configuration.MedicalConsultationConfigurations
{
    internal class HistoryConsultationConfiguration : IEntityTypeConfiguration<HistoryConsultation>
    {
        public void Configure(EntityTypeBuilder<HistoryConsultation> builder)
        {
            builder.ToTable("HistoryConsultations");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}