using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class ContactRepository : ISalesforceContactRepository
    {
        private readonly ISalesforceClient _client;

        public ContactRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<ContactSOQL> GetByIdAsync(string contactId)
        {
            try
            {
                string query = "SELECT ID, FirstName, LastName, BirthDate, Salutation, Email, Phone, MobilePhone, Fonction__C, Origine_du_contact__c, " +
                                "NPAI_Email__c, Opt_out__c, Opt_out_courrier__c, Opt_out_sms__c, Opt_out_t_l_phone__c, A_quitte_son_poste__c, " +
                                "Site_web__c, Source_marketing__c, Structure__c, Titre_de_la_carte_de_visite__c, Twitter__c, Linkedin__c, AccountId " +
                                "FROM Contact " +
                                "WHERE ID = '" + contactId + "'";

                var response = await _client.QueryAsync<ContactSOQL>(query);

                if (response.Records?.Count == 1)
                {
                    return response.Records[0];
                }
                else if (response.Records?.Count > 1)
                    throw new Exception("Multiple contacts found for Id: " + contactId);
                else
                    throw new Exception("Contact not found for Id: " + contactId);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
    }
}
