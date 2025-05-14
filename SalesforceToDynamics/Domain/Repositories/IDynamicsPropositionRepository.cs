using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsPropositionRepository
    {
        Guid CreateUpdate(PropositionDTO proposition);
    }
}
