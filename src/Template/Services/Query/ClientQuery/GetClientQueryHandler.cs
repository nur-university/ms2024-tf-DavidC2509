using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClientAggregate;
using Template.Domain.ClientAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.ClientQuery
{
    public class GetClientQueryHandler : BaseQueryHandler<Client, GetClientQuery, ClientModel>
    {
        private readonly IMapper _mapper;

        public GetClientQueryHandler(IReadRepository<Client> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<ClientModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetClientByIdSpec(request.Id);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            var resultMapper = _mapper.Map<ClientModel>(account);
            return resultMapper;
        }
    }
}