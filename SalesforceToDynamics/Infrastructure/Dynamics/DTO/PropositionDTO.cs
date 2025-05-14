
using Microsoft.Xrm.Sdk;
using System;
using SalesforceToDynamics.Helpers;


namespace SalesforceToDynamics.Infrastructure.Dynamics.DTO
{
    public class PropositionDTO
    {
        [DynamicsLogicalName("new_salesforceid")]
        public string SalesforceId { get; set; }

        [DynamicsLogicalName("name")]
        public string Titre { get; set; }

        [DynamicsLogicalName("new_date")]
        public DateTime DateProposition { get; set; }

        [DynamicsLogicalName("new_contact")]
        public EntityReference Contact { get; set; }

        [DynamicsLogicalName("customerid")]
        public EntityReference Compte { get; set; }

        [DynamicsLogicalName("ownerid")]
        public EntityReference Proprietaire { get; set; }

        [DynamicsLogicalName("new_divisioncci")]
        public EntityReference DivisionCCI { get; set; }
    }
}
