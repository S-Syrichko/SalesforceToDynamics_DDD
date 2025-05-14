using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsContactRepository
    {
        Guid CreateUpdate(ContactDTO contactData);
    }
}
