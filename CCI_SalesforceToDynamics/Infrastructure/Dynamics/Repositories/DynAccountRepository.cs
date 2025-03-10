using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Helpers;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynAccountRepository : IDynamicsAccountRepository
    {
        private readonly IDynamicsClient _client;
        public DynAccountRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid CreateUpdate(CompteDTO account)
        {
            try
            {
                QueryExpression query = new QueryExpression("account");
                query.Criteria.AddCondition("new_salesforceid", ConditionOperator.Equal, account.SalesforceId);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<CompteDTO>();
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _Accounts = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Accounts.Count > 1)
                {
                    throw new Exception($"Multiple Accounts found with SalesforceId: " + account.SalesforceId);
                }

                Entity _Account;
                if (_Accounts.Count == 0)
                {
                    _Account = DynamicsAttributesHelper.MapToNewEntity(account, "account");
                    return _client.Service.Create(_Account);
                }
                else
                {
                    _Account = DynamicsAttributesHelper.MapToExistingEntity(account, _Accounts[0]);
                    _client.Service.Update(_Account);

                    return _Account.Id;
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
