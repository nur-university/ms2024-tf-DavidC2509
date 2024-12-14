using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;

namespace Template.Domain.ClientAggregate
{
    public class Address : BaseEntity, IAggregateChild<Client>, IAggregateRoot
    {
        public string Street { get; set; }
        public string City { get; set; }
        public decimal Latituded { get; set; }
        public decimal Longitud { get; set; }
        public bool Status { get; set; }
        private readonly List<AddressHistory> _history;
        public IEnumerable<AddressHistory> History => _history.AsReadOnly();
        private Address()
        {
            Street = string.Empty;
            City = string.Empty;
            Latituded = 0;
            Longitud = 0;
            Status = false;
            _history = [];
        }

        internal Address(string street, string city, decimal latituded, decimal longitud) : this()
        {
            Street = street;
            City = city;
            Latituded = latituded;
            Longitud = longitud;
            Status = true;

        }

        public static Address StoreAddres(string street, string city, decimal latituded, decimal longitud)
            => new(street, city, latituded, longitud);

    }
}
