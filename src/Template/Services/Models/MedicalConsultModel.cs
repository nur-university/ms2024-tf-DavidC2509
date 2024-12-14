namespace Template.Services.Models
{
    public class MedicalConsultModel
    {
        public string Descripcion { get; set; }
        public bool Status { get; set; }
        public Guid IdConsultExternal { get; set; }
        public Guid IdClient { get; set; }
    }
}
