using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforceOpportunityLineRepository
    {
        Task<List<OpportunityLineSOQL>> GetByOpportunityIdAsync(string opportunityId);
    }
}
