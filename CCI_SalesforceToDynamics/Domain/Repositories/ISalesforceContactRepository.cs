using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceContactRepository
    {
        Task<ContactSOQL> GetByIdAsync(string contactId);
    }
}
