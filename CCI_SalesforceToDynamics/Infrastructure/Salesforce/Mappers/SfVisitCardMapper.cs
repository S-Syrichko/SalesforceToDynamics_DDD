using System;
using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfVisitCardMapper
    {
        public static CarteDeVisite Map(ContactSOQL contact)
        {
            DateTime? _dateFinFonction;

            if (bool.Parse(contact.A_quitte_son_poste__c) == true)
                _dateFinFonction = DateTime.Now;
            else
                _dateFinFonction = null;

            return new CarteDeVisite()
            {
                TelephoneStd = contact.Phone,
                TelephoneMobile = contact.MobilePhone,
                Email = contact.Email,
                Fonction = contact.Fonction__C,
                Service = contact.Structure__c,
                DateDeFinFonction = _dateFinFonction,
                Source = contact.Source_marketing__c,
                NePasAutoriserEmail = bool.Parse(contact.Opt_out__c),
                NePasAutoriserCourrier = bool.Parse(contact.Opt_out_courrier__c),
                NePasAutoriserTelephone = bool.Parse(contact.Opt_out_t_l_phone__c),
                NePasAutoriserSMS = bool.Parse(contact.Opt_out_sms__c),
                SiteWeb = contact.Site_web__c
            };
        }
    }
}
