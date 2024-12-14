using Ardalis.Specification;

namespace Template.Domain.MedicalConsultationAggregate.Specification
{
    public class ConsultationByIdSpec : Specification<Consultation>
    {
        public ConsultationByIdSpec(Guid id)
        {
            Query
                .Where(c => c.Id.Equals(id))
                .Include(c => c.HistoryConsultations);
        }
    }
}