using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Helpers;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    class DynPropositionRepository : IDynamicsPropositionRepository
    {
        private readonly IDynamicsClient _client;
        public DynPropositionRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid CreateUpdate(PropositionDTO proposition)
        {
            try
            {
                QueryExpression query = new QueryExpression("quote");
                query.Criteria.AddCondition("new_salesforceid", ConditionOperator.Equal, proposition.SalesforceId);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<PropositionDTO>();
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _Propositions = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Propositions.Count > 1)
                {
                    throw new Exception($"Multiple Propositions found with SalesforceId: " + proposition.SalesforceId);
                }

                Entity _Proposition;
                if (_Propositions.Count == 0)
                {
                    _Proposition = DynamicsAttributesHelper.MapToNewEntity(proposition, "quote");
                    return _client.Service.Create(_Proposition);
                }
                else
                {
                    _Proposition = DynamicsAttributesHelper.MapToExistingEntity(proposition, _Propositions[0]);
                    _client.Service.Update(_Proposition);
                    return _Proposition.Id;
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return Guid.Empty;

            }
        }
    }
}
