using Microsoft.Xrm.Sdk;
using CCI_SalesforceToDynamics.Helpers;


namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class ProduitDePropositionDTO
    {
        [DynamicsLogicalName("new_salesforceid")]
        public string SalesforceId { get; set; }

        [DynamicsLogicalName("quoteid")]
        public EntityReference Proposition { get; set; }

        [DynamicsLogicalName("productdescription")]
        public string Nom { get; set; }

        [DynamicsLogicalName("priceperunit")]
        public decimal PrixUnitaire { get; set; }

        [DynamicsLogicalName("quantity")]
        public decimal Quantite { get; set; }

        [DynamicsLogicalName("isproductoverridden")]
        public bool ProduitHorsCatalogue { get; set; }
    }
}