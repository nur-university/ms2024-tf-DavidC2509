using Ardalis.Specification;

namespace Template.Domain.MedicalConsultationAggregate.Specification
{
    public class ConsultationByClientSpec : Specification<Consultation>
    {
        public ConsultationByClientSpec(Guid idClient)
        {
            Query
                .Where(c => c.IdClient.Equals(idClient))
                .Include(c => c.HistoryConsultations);
        }
    }
}