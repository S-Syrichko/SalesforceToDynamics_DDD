using CCI_SalesforceToDynamics.Helpers;
using Microsoft.Xrm.Sdk;
using System;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class CarteDeVisiteDTO
    {
        [DynamicsLogicalName("new_contactassocie")]
        public EntityReference Contact { get; set; }

        [DynamicsLogicalName("parentcustomerid")]
        public EntityReference Compte { get; set; }

        [DynamicsLogicalName("emailaddress1")]
        public string Email { get; set; }

        [DynamicsLogicalName("telephone1")]
        public string Telephone { get; set; }

        [DynamicsLogicalName("mobilephone")]
        public string Mobile { get; set; }

        [DynamicsLogicalName("new_fonction")]
        public OptionSetValue Fonction { get; set; }

        [DynamicsLogicalName("department")]
        public string Service { get; set; }

        [DynamicsLogicalName("new_originesource")]
        public string SourceMarketing { get; set; }

        [DynamicsLogicalName("donotemail")]
        public bool NePasAutoriserEmail { get; set; }

        [DynamicsLogicalName("donotpostalmail")]
        public bool NePasAutoriserCourrier { get; set; }

        [DynamicsLogicalName("donotphone")]
        public bool NePasAutoriserTelephone { get; set; }

        [DynamicsLogicalName("new_donotsms")]
        public bool NePasAutoriserSMS { get; set; }

        [DynamicsLogicalName("new_datedefinfonction")]
        public DateTime? DateFinFonction { get; set; }

        [DynamicsLogicalName("websiteurl")]
        public string SiteWeb { get; set; }
    }
}
