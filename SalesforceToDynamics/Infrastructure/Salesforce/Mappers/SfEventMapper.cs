using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfEventMapper
    {
        public static RendezVous Map(EventSOQL sfEvent)
        {
            return new RendezVous()
            {
                IdentifiantSalesforce = sfEvent.Id,
                OrganisateurId = sfEvent.OwnerId,
                NecessaireId = sfEvent.WhoId,
                Sujet = sfEvent.Subject,
                TypeDeRDV = sfEvent.Type_de_rdv__c,
                HeureDebut = DateTime.Parse(sfEvent.StartDateTime),
                HeureFin = DateTime.Parse(sfEvent.EndDateTime),
                Emplacement = sfEvent.Location,
                CompteRendu = sfEvent.Description,
            };
        }
    }
}