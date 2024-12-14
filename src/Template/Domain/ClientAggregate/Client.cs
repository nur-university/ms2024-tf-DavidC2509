using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;

namespace Template.Domain.ClientAggregate
{
    public class Client : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }

        private readonly List<Address> _addresses;
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();

        private readonly List<MedicalIllnesses> _medicalIllnesses;
        public IEnumerable<MedicalIllnesses> MedicalIllnessess => _medicalIllnesses.AsReadOnly();

        private Client()
        {
            Name = string.Empty;
            Email = string.Empty;
            _addresses = [];
            _medicalIllnesses = [];
        }

        internal Client(string name, string phone, string email) : this()
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public static Client CreateClient(string name, string phone, string email)
            => new(name, phone, email);


        public void AddAddres(string street, string city, decimal latituded, decimal longitud)
        {
            _addresses.ForEach(address => address.Status = false);
            _addresses.Add(Address.StoreAddres(street, city, latituded, longitud));
        }

        public void AddMedicalIllnesses(string name, string descripcion, string type)
        {
            _medicalIllnesses.Add(MedicalIllnesses.StoreMedicalIllnesses(name, descripcion, type));
        }



    }
}
