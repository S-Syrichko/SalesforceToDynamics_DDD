using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsNAFCodeRepository
    {
        Guid GetGuidByCode(string code);
    }
}
