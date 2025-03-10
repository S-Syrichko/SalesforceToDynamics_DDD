using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Mappers
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
