using MediatR;

namespace Template.Services.Command.MedicalConsultCommand
{
    public class StoreMedicalConsultCommand : IRequest<bool>
    {
        public required Guid IdClient { get; set; }
        public required string Name { get; set; }
        public required bool Status { get; set; }
        public required Guid IdConsultExternal { get; set; }

    }
}