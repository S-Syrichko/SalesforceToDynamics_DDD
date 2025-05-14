using SalesforceToDynamics.Domain.Repositories;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynTeamRepository : IDynamicsTeamRepository
    {
        private readonly IDynamicsClient _client;
        public DynTeamRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid GetGuidByDivisionReference(Guid divisionId)
        {
            try
            {
                QueryExpression query = new QueryExpression("team");
                query.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, divisionId);
                query.ColumnSet = new ColumnSet("teamid");

                List<Entity> _Teams = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Teams.Count == 0)
                {
                    throw new Exception($"Team not found with DivisionId : {divisionId}");
                }
                else if (_Teams.Count > 1)
                {
                    throw new Exception($"Multiple Teams found with DivisionId : {divisionId}");
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
