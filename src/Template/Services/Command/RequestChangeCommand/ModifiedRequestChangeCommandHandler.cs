using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.RequestChangeAggregate;

namespace Template.Services.Command.RequestChangeCommand
{
    internal class ModifiedRequestChangeCommandHandler : BaseCommandHandler<IRepository<RequestChangeHistory>, ModifiedRequestChangeCommand, bool>
    {

        public ModifiedRequestChangeCommandHandler(IRepository<RequestChangeHistory> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(ModifiedRequestChangeCommand request, CancellationToken cancellationToken)
        {
            var consultation = RequestChangeHistory.CreateChangeHistory(request.IdAppointment, request.IdClient, request.PreviusDate, request.NewDate);
            _repository.Add(consultation);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
