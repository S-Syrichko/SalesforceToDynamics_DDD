using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace CCI_SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsPropositionProductRepository
    {
        Guid CreateUpdate(ProduitDePropositionDTO propositionProduct);
    }
}
