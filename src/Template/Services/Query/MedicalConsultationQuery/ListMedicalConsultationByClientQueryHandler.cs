using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MedicalConsultationAggregate;
using Template.Domain.MedicalConsultationAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.MedicalConsultationQuery
{
    public class ListMedicalConsultationByClientQueryHandler : BaseQueryHandler<Consultation, ListMedicalConsultationByClientQuery, IEnumerable<MedicalConsultModel>>
    {
        private readonly IMapper _mapper;

        public ListMedicalConsultationByClientQueryHandler(IReadRepository<Consultation> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<MedicalConsultModel>> Handle(ListMedicalConsultationByClientQuery request, CancellationToken cancellationToken)
        {
            var spec = new ConsultationByClientSpec(request.IdClient);
            var account = await _repository.ListAsync(spec, cancellationToken);

            var resultMapper = _mapper.Map<List<MedicalConsultModel>>(account);
            return resultMapper;
        }
    }
}