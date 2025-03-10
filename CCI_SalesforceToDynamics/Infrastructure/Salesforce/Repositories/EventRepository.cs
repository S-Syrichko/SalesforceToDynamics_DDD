using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Repositories
{
    public class EventRepository : ISalesforceEventRepository
    {
        private readonly ISalesforceClient _client;

        private static readonly int DaysToFetch = -Math.Abs(Properties.Settings.Default.DaysToFetch);
        private readonly string _dateLimit = DateTime.Now.AddDays(DaysToFetch).ToString("yyyy-MM-ddTHH:mm:ssZ");


        public EventRepository(ISalesforceClient salesforceClient)
        {
            _client = salesforceClient;
        }
        public async Task<List<EventSOQL>> GetAsync()
        {
            try
            {
                string query = "SELECT AccountId, Description, EndDateTime, Id, Location, Objet_CR_existant__c, OwnerId, StartDateTime, " +
                                "Statut_rdv__c, Subject, SystemModstamp, Type, type_activite__c, Type_de_rdv__c, WhoId, Compte_rendu__c " +
                                "FROM Event " +
                                "WHERE ownerid IN (SELECT ID FROM User WHERE Region_CCI__c = '27') " +
                                "AND type_activite__c = 'RDV' " +
                                "AND (CreatedDate >=" + _dateLimit + " OR LastModifiedDate >=" + _dateLimit + ")";

                var response = await _client.QueryAsync<EventSOQL>(query);

                return response.Records;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
    }
}
