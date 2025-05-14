using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class AccountRepository : ISalesforceAccountRepository
    {
        private readonly ISalesforceClient _client;

        public AccountRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<AccountSOQL> GetByIdAsync(string accountId)
        {
            try
            {
                string query = "SELECT SIRET__c, Id, Phone, Site_Web_Source_Officielle__c, Site, Sigle__c, Name, Objet_Social__c, " +
                                "Fax, Enseigne__c, Email_source_officielle__c, Email__c, Code_NAF__c, CreatedDate, ShippingCity, " +
                                "Code_Commune__c, ShippingCountry, ShippingPostalCode, ShippingStreet, Company__r.Forme_juridique__c " +
                                "FROM Account " +
                                "WHERE ID = '" + accountId + "'";

                var response = await _client.QueryAsync<AccountSOQL>(query);

                if (response.Records?.Count == 1)
                {
                    return response.Records[0];
                }
                else if (response.Records?.Count > 1)
                    throw new Exception("Multiple accounts found for Id: " + accountId);
                else
                    throw new Exception("Account not found for Id: " + accountId);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
    }
}
