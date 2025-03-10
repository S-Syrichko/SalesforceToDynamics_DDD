using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsTeamRepository
    {
        Guid GetGuidByDivisionReference(Guid divisionId);
    }
}
