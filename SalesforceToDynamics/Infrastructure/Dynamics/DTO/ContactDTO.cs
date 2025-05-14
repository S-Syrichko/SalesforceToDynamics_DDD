using Microsoft.Xrm.Sdk;
using System;
using SalesforceToDynamics.Helpers;


namespace SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class ContactDTO
    {
        [DynamicsLogicalName("new_salesforceid")]
        public string SalesforceId { get; set; }

        [DynamicsLogicalName("new_prenom")]
        public string Prenom { get; set; }

        [DynamicsLogicalName("new_nom")]
        public string Nom { get; set; }

        [DynamicsLogicalName("new_datedenaissance")]
        public DateTime? DateDeNaissance { get; set; }

        [DynamicsLogicalName("new_civilite")]
        public OptionSetValue Civilite { get; set; }

        [DynamicsLogicalName("new_originesource")]
        public string SourceContact { get; set; }
    }
}
