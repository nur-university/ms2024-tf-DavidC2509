using MediatR;
using Template.Domain.RequestChangeAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class NotifiedNutrionEventHandler : INotificationHandler<NotifiedNutrionEvent>
    {


        public NotifiedNutrionEventHandler()
        {

        }

        public async Task Handle(NotifiedNutrionEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Entro a evento de dominio el cliente" + notification.ClientId);

        }
    }
}