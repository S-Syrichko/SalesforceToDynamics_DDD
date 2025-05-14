using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsAccountRepository
    {
        Guid CreateUpdate(CompteDTO account);
    }
}
