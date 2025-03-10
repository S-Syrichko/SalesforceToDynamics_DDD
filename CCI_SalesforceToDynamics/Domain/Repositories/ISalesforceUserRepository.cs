using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceUserRepository
    {
        Task<List<UserSOQL>> GetAsync();
    }
}
