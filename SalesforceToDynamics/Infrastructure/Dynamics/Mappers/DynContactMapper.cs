using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynContactMapper
    {
        public static ContactDTO Map(Contact Contact)
        {
            OptionSetValue _civilite = new OptionSetValue();

            if (Contact.Civilite == "Madame")
                _civilite.Value = 100_000_000;
            else if (Contact.Civilite == "Monsieur")
                _civilite.Value = 100_000_001;
            else
                _civilite.Value = 100_000_002;

            return new ContactDTO()
            {
                SalesforceId = Contact.IdentifiantSalesforce,
                Prenom = Contact.Prenom,
                Nom = Contact.Nom,
                DateDeNaissance = Contact.DateDeNaissance,
                Civilite = _civilite,
                SourceContact = Contact.CarteDeVisite.Source,
            };
        }
    }
}
