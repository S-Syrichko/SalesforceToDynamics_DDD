using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsVisitCardRepository
    {
        Guid CreateUpdate(CarteDeVisiteDTO visitCard);
    }
}
