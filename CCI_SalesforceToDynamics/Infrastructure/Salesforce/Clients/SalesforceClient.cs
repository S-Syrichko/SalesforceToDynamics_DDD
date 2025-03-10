using CCI_SalesforceToDynamics.Domain.Repositories;
using Salesforce.Common;
using Salesforce.Common.Models.Json;
using Salesforce.Force;
using System.Net;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Clients
{
    public class SalesforceClient :ISalesforceClient
    {
        private readonly IForceClient _client;

        private SalesforceClient(IForceClient client)
        {
            _client = client;
        }

        public static async Task<ISalesforceClient> CreateAsync(
            string consumerKey,
            string consumerSecret,
            string username,
            string password,
            string loginUrl)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            IAuthenticationClient auth = new AuthenticationClient();
            await auth.UsernamePasswordAsync(consumerKey, consumerSecret, username, password, loginUrl);
            var forceClient = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
            return new SalesforceClient(forceClient);
        }

        public Task<QueryResult<T>> QueryAsync<T>(string query)
        {
            return _client.QueryAsync<T>(query);
        }

        public Task<QueryResult<T>> QueryContinuationAsync<T>(string nextRecordsUrl)
        {
            return _client.QueryContinuationAsync<T>(nextRecordsUrl);
        }
    }
}
