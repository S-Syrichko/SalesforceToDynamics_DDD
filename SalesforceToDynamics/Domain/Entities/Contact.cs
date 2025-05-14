using System;

namespace SalesforceToDynamics.Domain.Entities
{
    public class Contact
    {
        public string IdentifiantSalesforce { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Civilite { get; set; } = string.Empty;
        public DateTime? DateDeNaissance { get; set; }
        public CarteDeVisite CarteDeVisite { get; set; }
    }
}
