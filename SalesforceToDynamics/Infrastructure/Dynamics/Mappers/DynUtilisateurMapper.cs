using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Mappers
{
    public static class DynUtilisateurMapper
    {
        public static UtilisateurDTO Map(Utilisateur Utilisateur)
        {
            return new UtilisateurDTO() 
            {
                SalesforceId = Utilisateur.IdentifiantSalesforce,
                Email = Utilisateur.Email
            };
        }
    }
}
