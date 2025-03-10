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
    public class DynPropositionProductRepository : IDynamicsPropositionProductRepository
    {
        private readonly IDynamicsClient _client;
        public DynPropositionProductRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid CreateUpdate(ProduitDePropositionDTO propositionProduct)
        {
            try
            {
                QueryExpression query = new QueryExpression("quotedetail");
                query.Criteria.AddCondition("new_salesforceid", ConditionOperator.Equal, propositionProduct.SalesforceId);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<ProduitDePropositionDTO>();
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _Products = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_Products.Count > 1)
                {
                    throw new Exception($"Multiple Products found with SalesforceId: " + propositionProduct.SalesforceId);
                }

                Entity _Product;
                if (_Products.Count == 0)
                {
                    _Product = DynamicsAttributesHelper.MapToNewEntity(propositionProduct, "quotedetail");
                    return _client.Service.Create(_Product);
                }
                else
                {
                    _Product = DynamicsAttributesHelper.MapToExistingEntity(propositionProduct, _Products[0]);
                    _client.Service.Update(_Product);
                    return _Product.Id;
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
