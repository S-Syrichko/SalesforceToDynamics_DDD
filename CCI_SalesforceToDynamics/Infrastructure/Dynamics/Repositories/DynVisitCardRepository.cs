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
    public class DynVisitCardRepository : IDynamicsVisitCardRepository
    {
        private readonly IDynamicsClient _client;
        public DynVisitCardRepository(IDynamicsClient client)
        {
            _client = client;
        }

        public Guid CreateUpdate(CarteDeVisiteDTO visitCard)
        {
            try
            {
                QueryExpression query = new QueryExpression("contact");
                query.Criteria.AddCondition("new_contactassocie", ConditionOperator.Equal, visitCard.Contact.Id);
                query.Criteria.AddFilter(LogicalOperator.And);
                query.Criteria.AddCondition("parentcustomerid", ConditionOperator.Equal, visitCard.Compte.Id);

                var attributeNames = DynamicsAttributesHelper.GetDynamicsAttributeNames<CarteDeVisiteDTO>();
                query.ColumnSet = new ColumnSet(attributeNames);

                List<Entity> _VisitCards = _client.Service.RetrieveMultiple(query).Entities.ToList();

                if (_VisitCards.Count > 1)
                {
                    throw new Exception($"Multiple Visit Cards found with Contact: {visitCard.Contact} " +
                                        $"Account: {visitCard.Compte}");
                }

                Entity _VisitCard;
                if (_VisitCards.Count == 0)
                {
                    _VisitCard = DynamicsAttributesHelper.MapToNewEntity(visitCard, "contact");
                    return _client.Service.Create(_VisitCard);
                }
                else
                {
                    _VisitCard = DynamicsAttributesHelper.MapToExistingEntity(visitCard, _VisitCards[0]);
                    _client.Service.Update(_VisitCard);
                    return _VisitCard.Id;
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
