using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfProductMapper
    {
        public static ProduitDeProposition Map(PrestationSOQL prestation)
        {
            decimal _amount = 0;

            if (prestation.Montant_comptabilis_CI_CAI__c != null)
                _amount = decimal.Parse(prestation.Montant_comptabilis_CI_CAI__c.Replace(".", ","));
            else if (prestation.Montant__c != null)
                _amount = decimal.Parse(prestation.Montant__c.Replace(".", ","));

            return new ProduitDeProposition()
            {
                IdentifiantSalesforce = prestation.Id,
                ProduitHorsCatalogue = prestation.Name,
                PrixUnitaire = _amount,
                Quantite = 1
            };
        }
        public static ProduitDeProposition Map(OpportunityLineSOQL opportunityLine)
        {
            decimal _amount = 0;

            if (opportunityLine.MontantTotalHT__c != null)
                _amount = decimal.Parse(opportunityLine.MontantTotalHT__c.Replace(".", ","));
            else if (opportunityLine.UnitPrice != null)
                _amount = decimal.Parse(opportunityLine.UnitPrice.Replace(".", ","));

            return new ProduitDeProposition()
            {
                IdentifiantSalesforce = opportunityLine.Product2Id,
                ProduitHorsCatalogue = opportunityLine.Name,
                PrixUnitaire = _amount,
                Quantite = decimal.Parse(opportunityLine.Quantity.Replace(".", ","))
            };
        }
    }
}
