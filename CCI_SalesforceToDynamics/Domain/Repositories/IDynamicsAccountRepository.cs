using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsAccountRepository
    {
        Guid CreateUpdate(CompteDTO account);
    }
}
