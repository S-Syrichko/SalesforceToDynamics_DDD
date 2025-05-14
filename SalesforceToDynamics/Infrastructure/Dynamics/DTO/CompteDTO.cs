using Microsoft.Xrm.Sdk;
using SalesforceToDynamics.Helpers;


namespace SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class CompteDTO
    {
        [DynamicsLogicalName("new_salesforceid")]
        public string SalesforceId { get; set; }

        [DynamicsLogicalName("new_raisonsociale")]
        public string RaisonSociale { get; set; }

        [DynamicsLogicalName("new_enseigne")]
        public string Enseigne { get; set; }

        [DynamicsLogicalName("new_nomcommercialsigle")]
        public string Sigle { get; set; }

        [DynamicsLogicalName("new_siret")]
        public string Siret { get; set; }

        [DynamicsLogicalName("new_codenaf")]
        public EntityReference CodeNaf { get; set; }

        [DynamicsLogicalName("telephone1")]
        public string Telephone { get; set; }

        [DynamicsLogicalName("emailaddress1")]
        public string Email { get; set; }

        [DynamicsLogicalName("websiteurl")]
        public string SiteWeb { get; set; }

        [DynamicsLogicalName("address1_line1")]
        public string Adresse { get; set; }

        [DynamicsLogicalName("address1_postalcode")]
        public string CodePostal { get; set; }

        [DynamicsLogicalName("address1_city")]
        public string Ville { get; set; }

        [DynamicsLogicalName("address1_country")]
        public string Pays { get; set; }

        [DynamicsLogicalName("ownerid")]
        public EntityReference Owner { get; set; }

        [DynamicsLogicalName("new_activiteprincipale")]
        public string ActivitePrincipale { get; set; }

        [DynamicsLogicalName("fax")]
        public string Fax { get; set; }

        [DynamicsLogicalName("new_codeinsee")]
        public EntityReference CodeINSEE { get; set; }
    }
}
