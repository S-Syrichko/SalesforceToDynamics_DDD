using System;

namespace SalesforceToDynamics.Domain.Entities
{
    public class RendezVous
    {
        public string IdentifiantSalesforce { get; set; } = string.Empty;
        public string OrganisateurId { get; set; } = string.Empty;
        public string NecessaireId { get; set; } = string.Empty;
        public string Sujet { get; set; } = string.Empty;
        public string TypeDeRDV { get; set; } = string.Empty;
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public string Emplacement { get; set; } = string.Empty;
        public Concernant Concernant { get; set; }
        public string CompteRendu { get; set; } = string.Empty;
    }

    public class Concernant
    {
        public int CodeEntite { get; set; }
        public Guid DynamicsId { get; set; } = Guid.Empty;
    }
}
