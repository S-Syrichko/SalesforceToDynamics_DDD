using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using Sentry;
using System.Linq;
using CCI_SalesforceToDynamics.Domain.Repositories;

namespace CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories
{
    public class DynNAFCodeRepository : IDynamicsNAFCodeRepository
    {
        private readonly IDynamicsClient _client;
        public DynNAFCodeRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid GetGuidByCode(string code)
        {
            try
            {
                QueryExpression query = new QueryExpression("new_codenaf");
                query.Criteria.AddCondition("new_code", ConditionOperator.Equal, code);
                query.ColumnSet = new ColumnSet("new_codenafid");

                List<Entity> _Codes = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Codes.Count == 0)
                {
                    throw new Exception($"Code NAF not found for Code : {code}");
                }
                else if (_Codes.Count > 1)
                {
                    throw new Exception($"Multiple Codes NAF found for Code : {code}");
                }

                return _Codes[0].Id;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return Guid.Empty;
            }
        }
    }
}
