using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsNAFCodeRepository
    {
        Guid GetGuidByCode(string code);
    }
}
