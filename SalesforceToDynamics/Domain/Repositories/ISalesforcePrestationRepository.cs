using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface ISalesforcePrestationRepository
    {
        Task<List<PrestationSOQL>> GetByOpportunityIdAsync(string opportunityId);
    }
}
