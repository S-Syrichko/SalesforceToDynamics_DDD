using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using CCI_SalesforceToDynamics.Domain.Repositories;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynDivisionRepository : IDynamicsDivisionRepository
    {
        private readonly IDynamicsClient _client;
        public DynDivisionRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid GetGuidByName(string name)
        {
            try
            {
                QueryExpression query = new QueryExpression("businessunit");
                query.Criteria.AddCondition("name", ConditionOperator.Equal, name);
                query.ColumnSet = new ColumnSet("businessunitid");

                List<Entity> _Teams = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Teams.Count == 0)
                {
                    throw new Exception($"Businessunit not found with Name : {name}");
                }
                else if (_Teams.Count > 1)
                {
                    throw new Exception($"Multiple Businessunits found with Name : {name}");
                }

                return _Teams[0].Id;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return Guid.Empty;
            }
        }
    }
}
