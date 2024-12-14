using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;
using MediatR;
using Template.Domain.RequestChangeAggregate.Events;

namespace Template.Domain.RequestChangeAggregate
{
    public class RequestChangeHistory : DomainEventEntity, IAggregateRoot
    {
        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }

        public DateTime PreviusDate { get; set; }
        public DateTime NewDate { get; set; }
        public DateTime RegisterDate { get; set; }


        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private List<INotification> _domainEvents = new();

        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private List<INotification> _domainEventsAwait = new();



        private RequestChangeHistory()
        {

        }

        internal RequestChangeHistory(Guid idAppointment, Guid idClient, DateTime previusDate, DateTime newDate) : this()
        {
            IdAppointment = idAppointment;
            IdClient = idClient;
            PreviusDate = previusDate;
            NewDate = newDate;
            RegisterDate = DateTime.Now.ToUniversalTime();
            AddNotifiedNutrionEvent();
        }

        public static RequestChangeHistory CreateChangeHistory(Guid idAppointment, Guid idClient, DateTime previusDate, DateTime newDate)
            => new(idAppointment, idClient, previusDate, newDate);



        public void AddNotifiedNutrionEvent()
        {
            var categoryDefaultEvent = new NotifiedNutrionEvent(IdClient);
            _domainEventsAwait.Add(categoryDefaultEvent);
        }

    }
}
