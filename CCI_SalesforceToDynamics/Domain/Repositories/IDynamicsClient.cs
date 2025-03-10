using Microsoft.Xrm.Sdk;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsClient
    {
        IOrganizationService Service { get; }
    }
}
