using CCI_SalesforceToDynamics.Helpers;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using CCI_SalesforceToDynamics.Domain.Repositories;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynContactRepository : IDynamicsContactRepository
    {
        private readonly IDynamicsClient _client;
        public DynContactRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid CreateUpdate(ContactDTO contactData)
        {
            try
            {
                QueryExpression query = new QueryExpression("new_contact");

                query.Criteria.AddCondition("new_nom", ConditionOperator.Equal, contactData.Nom);
                query.Criteria.AddFilter(LogicalOperator.And);
                query.Criteria.AddCondition("new_prenom", ConditionOperator.Equal, contactData.Prenom);
                if (contactData.DateDeNaissance != null)
                    query.Criteria.AddCondition("new_datedenaissance", ConditionOperator.Equal, contactData.DateDeNaissance);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<ContactDTO>();
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _Contacts = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Contacts.Count > 1)
                {
                    throw new Exception($"Multiple Contacts found with " +
                        $"FirstName: {contactData.Prenom}, " +
                        $"LastName: {contactData.Nom}, " +
                        $"BirthDate: {contactData.DateDeNaissance}");
                }

                Entity _Contact;
                if (_Contacts.Count == 0)
                {
                    _Contact = DynamicsAttributesHelper.MapToNewEntity(contactData, "new_contact");
                    return _client.Service.Create(_Contact);
                }
                else
                {
                    _Contact = DynamicsAttributesHelper.MapToExistingEntity(contactData, _Contacts[0]);
                    _client.Service.Update(_Contact);
                    return _Contact.Id;
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return Guid.Empty;
            }
        }
    }
}
