using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceAccountRepository
    {
        Task<AccountSOQL> GetByIdAsync(string accountId);
    }
}
