using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsDivisionRepository
    {
        Guid GetGuidByName(string name);
    }
}
