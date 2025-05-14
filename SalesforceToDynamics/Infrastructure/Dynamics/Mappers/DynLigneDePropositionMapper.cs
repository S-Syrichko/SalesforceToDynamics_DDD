using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using System;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
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
