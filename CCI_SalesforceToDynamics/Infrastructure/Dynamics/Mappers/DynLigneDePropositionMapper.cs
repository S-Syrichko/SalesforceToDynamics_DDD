using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using System;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynLigneDePropositionMapper
    {
        public static ProduitDePropositionDTO Map(ProduitDeProposition ProduitDeProposition, Guid PropositionId)
        {
            return new ProduitDePropositionDTO()
            {
                Proposition = new EntityReference("quote", PropositionId),
                SalesforceId = ProduitDeProposition.IdentifiantSalesforce,
                Nom = ProduitDeProposition.ProduitHorsCatalogue,
                PrixUnitaire = ProduitDeProposition.PrixUnitaire,
                Quantite = ProduitDeProposition.Quantite,
                ProduitHorsCatalogue = true,
            };
        }
    }
}
