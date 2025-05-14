using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using System;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynCompteMapper
    {
        public static CompteDTO Map(Compte Compte, Guid codeNafId, Guid equipeId)
        {
            return new CompteDTO()
            {
                SalesforceId = Compte.IdentifiantSalesforce,
                RaisonSociale = Compte.RaisonSociale,
                Enseigne = Compte.Enseigne,
                Sigle = Compte.Sigle,
                Siret = Compte.Siret,
                CodeNaf = new EntityReference("new_codenaf", codeNafId),
                Telephone = Compte.Telephone,
                Email = Compte.Email,
                SiteWeb = Compte.SiteWeb,
                Adresse = Compte.Adresse,
                CodePostal = Compte.CodePostal,
                Ville = Compte.Ville,
                Pays = Compte.Pays,
                Owner = new EntityReference("team", equipeId),
                ActivitePrincipale = Compte.ActivitePrincipale,
                Fax = Compte.Fax
            };
        }
    }
}