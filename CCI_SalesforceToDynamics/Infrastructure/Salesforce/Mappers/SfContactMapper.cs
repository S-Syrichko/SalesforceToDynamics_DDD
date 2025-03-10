using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfContactMapper
    {
        public static Contact Map(ContactSOQL contact)
        {
            return new Contact()
            {
                IdentifiantSalesforce = contact.Id,
                Nom = contact.LastName,
                Prenom = contact.FirstName,
                Civilite = contact.Salutation,
                DateDeNaissance = !String.IsNullOrEmpty(contact.BirthDate) ? DateTime.Parse(contact.BirthDate) : (DateTime?)null,
                CarteDeVisite = SfVisitCardMapper.Map(contact)
            };
        }
    }
}
