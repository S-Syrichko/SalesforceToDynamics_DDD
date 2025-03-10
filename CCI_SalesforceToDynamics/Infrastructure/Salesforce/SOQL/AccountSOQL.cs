
namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL
{
    public class AccountSOQL
    {
        public string Siret__c { get; set; }
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Site_Web_Source_Officielle__c { get; set; }
        public string Site { get; set; }
        public string Sigle__c { get; set; }
        public string Name { get; set; }
        public string Objet_Social__c { get; set; }
        public string Fax { get; set; }
        public string Enseigne__c { get; set; }
        public string Email_source_officielle__c { get; set; }
        public string Email__c { get; set; }
        public string Code_NAF__c { get; set; }
        public string CreatedDate { get; set; }
        public string ShippingCity { get; set; }
        public string Code_Commune__c { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingStreet { get; set; }
        public CompanySOQL Company__r { get; set; }
    }
}
