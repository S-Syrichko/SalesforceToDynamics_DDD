namespace SalesforceToDynamics.Domain.Entities
{
    public class ProduitDeProposition
    {
        public string IdentifiantSalesforce { get; set; } = string.Empty;
        public string ProduitHorsCatalogue { get; set; } = string.Empty;
        public decimal PrixUnitaire { get; set; } = 0;
        public decimal Quantite { get; set; } = 0;
    }
}
