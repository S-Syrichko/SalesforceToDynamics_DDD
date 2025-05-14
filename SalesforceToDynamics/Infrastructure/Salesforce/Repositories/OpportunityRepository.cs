using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class OpportunityRepository : ISalesforceOpportunityRepository
    {
        private readonly ISalesforceClient _client;

        private static readonly int DaysToFetch = -Math.Abs(Properties.Settings.Default.DaysToFetch);
        private readonly string _dateLimit = DateTime.Now.AddDays(DaysToFetch).ToString("yyyy-MM-ddTHH:mm:ssZ");

        public OpportunityRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<List<OpportunitySOQL>> GetAsync()
        {
            try
            {
                //Get Opportunities created or modified by BFC User
                string query = "SELECT Id, CreatedDate, Descriptif_du_projet__c, StageName, Contact_opportunite__c, OwnerId, Name, AccountId, " +
                                "Account.ShippingPostalCode, Qualifie_par_commercial__c " +
                                "FROM Opportunity " +
                                "WHERE CreatedById IN (SELECT Id FROM User WHERE Region_CCI__c = '27') " +
                                "AND (CreatedDate >=" + _dateLimit + " OR LastModifiedDate >=" + _dateLimit + ")";

                var response = await _client.QueryAsync<OpportunitySOQL>(query);

                List<OpportunitySOQL> Opportunities = new List<OpportunitySOQL>();
                Opportunities.AddRange(response.Records);

                while (!response.Done)
                {
                    response = await _client.QueryContinuationAsync<OpportunitySOQL>(response.NextRecordsUrl);
                    Opportunities.AddRange(response.Records);
                }

                return Opportunities;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
    }
}
