using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsTeamRepository
    {
        Guid GetGuidByDivisionReference(Guid divisionId);
    }
}
