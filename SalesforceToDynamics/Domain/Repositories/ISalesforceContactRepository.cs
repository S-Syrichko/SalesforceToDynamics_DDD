using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceContactRepository
    {
        Task<ContactSOQL> GetByIdAsync(string contactId);
    }
}
