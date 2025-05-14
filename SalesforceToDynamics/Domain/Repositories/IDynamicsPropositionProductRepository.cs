using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using System;

namespace SalesforceToDynamics.Domain.Repositories
{
    public interface IDynamicsPropositionProductRepository
    {
        Guid CreateUpdate(ProduitDePropositionDTO propositionProduct);
    }
}
