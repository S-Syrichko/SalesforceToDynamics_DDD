using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfUserMapper
    {
        public static Utilisateur Map(UserSOQL sfUser)
        {
            return new Utilisateur()
            {
                IdentifiantSalesforce = sfUser.Id,
                Email = sfUser.Email,
            };
        }
    }
}
