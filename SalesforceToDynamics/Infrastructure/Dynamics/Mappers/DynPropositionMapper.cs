using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using System;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynPropositionMapper
    {
        public static PropositionDTO Map(Proposition Proposition, Guid carteVisiteId, Guid compteId, Guid utilisateurId, Guid divisionId)
        {
            if (utilisateurId != Guid.Empty)
            {
                return new PropositionDTO()
                {
                    SalesforceId = Proposition.IdentifiantSalesforce,
                    Titre = Proposition.Titre,
                    DateProposition = Proposition.DateProposition,
                    Contact = new EntityReference("contact", carteVisiteId),
                    Compte = new EntityReference("account", compteId),
                    Proprietaire = new EntityReference("systemuser", utilisateurId),
                    DivisionCCI = new EntityReference("businessunit", divisionId),
                };
            }
            else
            {
                return new PropositionDTO()
                {
                    SalesforceId = Proposition.IdentifiantSalesforce,
                    Titre = Proposition.Titre,
                    DateProposition = Proposition.DateProposition,
                    Contact = new EntityReference("new_contact", carteVisiteId),
                    Compte = new EntityReference("account", compteId),
                    DivisionCCI = new EntityReference("businessunit", divisionId),
                };
            }
        }
    }
}
