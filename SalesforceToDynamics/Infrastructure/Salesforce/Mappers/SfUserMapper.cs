using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Salesforce.SOQL;

namespace SalesforceToDynamics.Infrastructure.Salesforce.Mappers
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
