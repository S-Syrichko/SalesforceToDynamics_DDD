using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceAccountRepository
    {
        Task<AccountSOQL> GetByIdAsync(string accountId);
    }
}
