using System;

namespace SalesforceToDynamics.Domain.Entities
{
    public class CarteDeVisite
    {
        public Guid ContactAssocie { get; set; } = Guid.Empty;
        public Guid Societe { get; set; } = Guid.Empty;
        public string TelephoneStd { get; set; } = string.Empty;
        public string TelephoneMobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Fonction { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public DateTime? DateDeFinFonction { get; set; }
        public string Source { get; set; } = string.Empty;
        public bool NePasAutoriserEmail { get; set; } = false;
        public bool NePasAutoriserCourrier { get; set; } = false;
        public bool NePasAutoriserTelephone { get; set; } = false;
        public bool NePasAutoriserSMS { get; set; } = false;
        public string SiteWeb { get; set; } = string.Empty;
    }
}
