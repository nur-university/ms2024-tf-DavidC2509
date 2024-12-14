using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;

namespace Template.Domain.ClientAggregate
{
    public class MedicalIllnesses : BaseEntity, IAggregateChild<Client>
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Type { get; set; }
        public DateTime DateFound { get; set; }

        private MedicalIllnesses()
        {
            Name = string.Empty;
            Descripcion = string.Empty;
            Type = string.Empty;
        }


        internal MedicalIllnesses(string name, string descripcion, string type) : this()
        {
            Name = name;
            Descripcion = descripcion;
            Type = type;
            DateFound = DateTime.Now.ToUniversalTime();

        }

        public static MedicalIllnesses StoreMedicalIllnesses(string name, string descripcion, string type)
            => new(name, descripcion, type);
    }
}
