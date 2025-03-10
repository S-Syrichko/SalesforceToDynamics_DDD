using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsPropositionRepository
    {
        Guid CreateUpdate(PropositionDTO proposition);
    }
}
