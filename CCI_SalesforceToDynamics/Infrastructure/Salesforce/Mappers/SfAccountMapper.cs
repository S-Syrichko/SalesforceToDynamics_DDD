using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfAccountMapper
    {
        public static Compte Map(AccountSOQL account)
        {
            string _email = String.Empty;
            string _siteWeb = String.Empty;

            if (account.Email_source_officielle__c != null)
                _email = account.Email_source_officielle__c;
            else if (account.Email__c != null)
                _email = account.Email__c;

            if(account.Site_Web_Source_Officielle__c != null)
                _siteWeb = account.Site_Web_Source_Officielle__c;
            else if (account.Site != null)
                _siteWeb = account.Site;

            return new Compte()
            {
                IdentifiantSalesforce = account.Id,
                RaisonSociale = account.Name,
                Enseigne = account.Enseigne__c,
                Sigle = account.Sigle__c,
                Siret = account.Siret__c,
                FormeJuridique = account.Company__r.Forme_juridique__c,
                CodeNaf = account.Code_NAF__c,
                Telephone = account.Phone,
                Fax = account.Fax,
                Email = _email,
                SiteWeb = _siteWeb,
                Adresse = account.ShippingStreet,
                CodePostal = account.ShippingPostalCode,
                Ville = account.ShippingCity,
                Pays = account.ShippingCountry,
                ActivitePrincipale = account.Objet_Social__c,
                CodeINSEE = account.Code_Commune__c
            };
        }
    }
}