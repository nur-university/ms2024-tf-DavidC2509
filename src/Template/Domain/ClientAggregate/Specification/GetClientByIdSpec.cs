using Ardalis.Specification;

namespace Template.Domain.ClientAggregate.Specification
{
    public class GetClientByIdSpec : Specification<Client>
    {
        public GetClientByIdSpec(Guid id)
        {
            Query
                .Where(c => c.Id.Equals(id))
                .Include(c => c.Addresses);
        }
    }
}