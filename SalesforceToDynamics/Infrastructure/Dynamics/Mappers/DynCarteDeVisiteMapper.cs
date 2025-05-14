using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using System;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynCarteDeVisiteMapper
    {
        public static CarteDeVisiteDTO Map(CarteDeVisite CarteDeVisite, Guid contactId, Guid compteId)
        {

            return new CarteDeVisiteDTO()
            {
                Contact = new EntityReference("new_contact", contactId),
                Compte = new EntityReference("account", compteId),
                Email = CarteDeVisite.Email,
                Telephone = CarteDeVisite.TelephoneStd,
                Mobile = CarteDeVisite.TelephoneMobile,
                Fonction = GetFunctionOptionSetValue(CarteDeVisite.Fonction),
                Service = CarteDeVisite.Service,
                SourceMarketing = CarteDeVisite.Source,
                NePasAutoriserEmail = CarteDeVisite.NePasAutoriserEmail,
                NePasAutoriserCourrier = CarteDeVisite.NePasAutoriserCourrier,
                NePasAutoriserTelephone = CarteDeVisite.NePasAutoriserTelephone,
                NePasAutoriserSMS = CarteDeVisite.NePasAutoriserSMS,
                DateFinFonction = CarteDeVisite.DateDeFinFonction ?? null,
                SiteWeb = CarteDeVisite.SiteWeb
            };
        }

        private static OptionSetValue GetFunctionOptionSetValue(string functionName)
        {
            OptionSetValue _fonction = new OptionSetValue();
            switch (functionName)
            {
                case "Assistant(e)":
                    _fonction = new OptionSetValue(100_000_013);
                    break;
                case "Chargé(e) de mission":
                case "Chef de projet":
                    _fonction = new OptionSetValue(100_000_075);
                    break;
                case "Commercial":
                    _fonction = new OptionSetValue(100_000_000);
                    break;
                case "Comptable":
                    _fonction = new OptionSetValue(100_000_029);
                    break;
                case "Directeur(trice) de site ou d'exploitation":
                    _fonction = new OptionSetValue(100_000_002);
                    break;
                default:
                    _fonction = new OptionSetValue(100_000_079);
                    break;
            }

            return _fonction;
        }
    }
}
