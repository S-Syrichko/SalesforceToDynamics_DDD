using Salesforce.Common.Models.Json;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceClient
    {
        Task<QueryResult<T>> QueryAsync<T>(string query);
        Task<QueryResult<T>> QueryContinuationAsync<T>(string nextRecordsUrl);
    }
}
