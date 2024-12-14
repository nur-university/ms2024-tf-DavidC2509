using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClientAggregate;
using Template.Services.Models;

namespace Template.Services.Query.ClientQuery
{
    public class ListClientQueryHandler : BaseQueryHandler<Client, ListClientQuery, IEnumerable<ClientModel>>
    {
        private readonly IMapper _mapper;

        public ListClientQueryHandler(IReadRepository<Client> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<ClientModel>> Handle(ListClientQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.ListAsync(cancellationToken);
            Console.WriteLine("Obtuvo listado : " + list.Count);

            var resultMapper = _mapper.Map<List<ClientModel>>(list);
            return resultMapper;
        }
    }
}