using CCI_SalesforceToDynamics.Domain.Repositories;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using CCI_SalesforceToDynamics.Helpers;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynUserRepository: IDynamicsUserRepository
    {
        private readonly IDynamicsClient _client;
        public DynUserRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid Update(UtilisateurDTO userData)
        {
            try
            {
                QueryExpression query = new QueryExpression("systemuser");
                query.Criteria.AddCondition("internalemailaddress", ConditionOperator.Equal, userData.Email);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<UtilisateurDTO>();
                attributeNames.Append("systemuserid");
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _Users = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Users.Count == 0)
                {
                    //throw new Exception($"User not found for Email : {userData.Email}");
                    return Guid.Empty;
                }
                else if (_Users.Count > 1)
                {
                    throw new Exception($"Multiple Users found for Email : {userData.Email}");
                }

                Entity _User = _Users[0];

                _User = DynamicsAttributesHelper.MapToExistingEntity(userData, _Users[0]);
                _client.Service.Update(_User);

                return _User.Id;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return Guid.Empty;
            }
        }

        public Guid GetBySalesforceId(string salesforceId)
        {
            try
            {
                QueryExpression query = new QueryExpression("systemuser");
                query.Criteria.AddCondition("new_salesforceid", ConditionOperator.Equal, salesforceId);
                query.ColumnSet = new ColumnSet("systemuserid");
                List<Entity> _Users = _client.Service.RetrieveMultiple(query).Entities.ToList();
                if (_Users.Count == 0)
                {
                    //throw new Exception($"User not found for SalesforceId : {salesforceId}");
                    return Guid.Empty;
                }
                else if (_Users.Count > 1)
                {
                    throw new Exception($"Multiple Users found for SalesforceId : {salesforceId}");
                }
                return _Users[0].Id;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return Guid.Empty;
            }
        }
    }
}
