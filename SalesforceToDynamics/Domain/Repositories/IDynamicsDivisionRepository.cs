using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsDivisionRepository
    {
        Guid GetGuidByName(string name);
    }
}
