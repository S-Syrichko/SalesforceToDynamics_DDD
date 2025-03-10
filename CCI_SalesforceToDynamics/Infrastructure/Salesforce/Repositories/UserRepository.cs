using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class UserRepository : ISalesforceUserRepository
    {
        private readonly ISalesforceClient _client;

        public UserRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }

        public async Task<List<UserSOQL>> GetAsync()
        {
            try
            {
                //Region_CCI__c = 27 for CCI BFC
                string query = "SELECT Id, Email " +
                                   "FROM User " +
                                   "WHERE Region_CCI__c = '27'";

                var response = await _client.QueryAsync<UserSOQL>(query);

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
