using Microsoft.Xrm.Sdk;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsClient
    {
        IOrganizationService Service { get; }
    }
}
