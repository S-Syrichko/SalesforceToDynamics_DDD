using CCI_SalesforceToDynamics.Helpers;


namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class UtilisateurDTO
    {
        [DynamicsLogicalName("new_salesforceid")]
        public string SalesforceId { get; set; }

        [DynamicsLogicalName("internalemailaddress")]
        public string Email { get; set; }
    }
}
