using MediatR;

namespace Template.Services.Command.ClientCommand
{
    public class AddMedicalIllnessesCommand : IRequest<bool>
    {
        public required Guid IdClient { get; set; }
        public required string Name { get; set; }
        public required string Descripcion { get; set; }
        public required string Type { get; set; }

    }
}