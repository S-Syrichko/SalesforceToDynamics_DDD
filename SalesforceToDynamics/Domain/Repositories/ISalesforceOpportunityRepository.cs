using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceOpportunityRepository
    {
        Task<List<OpportunitySOQL>> GetAsync();
    }
}
