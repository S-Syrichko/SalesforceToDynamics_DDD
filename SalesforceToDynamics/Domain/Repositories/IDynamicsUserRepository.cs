using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsUserRepository
    {
        Guid Update(UtilisateurDTO userData);
        Guid GetBySalesforceId(string salesforceId);
    }
}
