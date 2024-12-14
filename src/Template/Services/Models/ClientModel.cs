﻿using Template.Domain.ClientAggregate;

namespace Template.Services.Models
{
    public class ClientModel
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string EmailAddres { get; set; }
        public List<AddresModel> Addresses { get; set; }
        public List<MedicalIllnesses> MedicalIllnessess { get; set; }

    }
}
