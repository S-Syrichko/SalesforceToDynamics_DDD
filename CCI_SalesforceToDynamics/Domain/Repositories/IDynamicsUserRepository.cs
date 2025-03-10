using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsUserRepository
    {
        Guid Update(UtilisateurDTO userData);
        Guid GetBySalesforceId(string salesforceId);
    }
}
