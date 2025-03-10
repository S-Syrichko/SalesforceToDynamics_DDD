
namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL
{
    public class OpportunitySOQL
    {
        public string Id { get; set; }
        public string CreatedDate { get; set; }
        public string Descriptif_du_projet__c { get; set; }
        public string StageName { get; set; }
        public string Contact_opportunite__c { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public string Qualifie_par_commercial__c { get; set; }
        public AccountSOQL Account { get; set; }
    }
}
