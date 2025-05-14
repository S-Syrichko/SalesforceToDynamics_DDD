using System;
using System.Collections.Generic;

namespace SalesforceToDynamics.Domain.Entities
{
    public class Proposition
    {
        public string IdentifiantSalesforce { get; set; } = string.Empty;
        public string Titre { get; set; } = string.Empty;
        public DateTime DateProposition { get; set; }
        public string Description { get; set; } = string.Empty;
        public string DivisionCCI { get; set; } = string.Empty;
        public List<ProduitDeProposition> Produits { get; set; }
        public Contact Contact { get; set; }
        public Compte Compte { get; set; }
        public string Proprietaire { get; set; } = string.Empty;
    }
}
