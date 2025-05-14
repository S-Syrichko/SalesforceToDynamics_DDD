using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class OpportunityLineRepository : ISalesforceOpportunityLineRepository
    {
        private readonly ISalesforceClient _client;

        public OpportunityLineRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<List<OpportunityLineSOQL>> GetByOpportunityIdAsync(string opportunityId)
        {
            try
            {
                string query = "SELECT CreatedDate, MontantTotalHT__c, Product2Id, Quantity, Name, UnitPrice, TVATauxElementDevis__c " +
                                "FROM OpportunityLineItem " +
                                "WHERE OpportunityId = '" + opportunityId + "'";

                var response = await _client.QueryAsync<OpportunityLineSOQL>(query);

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
