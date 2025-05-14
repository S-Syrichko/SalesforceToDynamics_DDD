using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class PrestationRepository : ISalesforcePrestationRepository
    {
        private readonly ISalesforceClient _client;

        public PrestationRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<List<PrestationSOQL>> GetByOpportunityIdAsync(string opportunityId)
        {
            try
            {

                string query = "SELECT Montant_comptabilis_CI_CAI__c, Name, id, CreatedDate, Montant__c " +
                                "FROM Services_propos_s__c " +
                                "WHERE Opportunity__c='" + opportunityId + "'";

                var response = await _client.QueryAsync<PrestationSOQL>(query);

                return response.Records;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
    }
}
