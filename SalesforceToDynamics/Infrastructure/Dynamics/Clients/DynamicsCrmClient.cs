using SalesforceToDynamics.Domain.Repositories;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;

namespace SalesforceToDynamics.Infrastructure.Dynamics.Clients
{
    public class DynamicsCrmClient : IDynamicsClient
    {
        private readonly IOrganizationService _service;

        public DynamicsCrmClient(string connectionString)
        {
            ServiceClient crmService = new ServiceClient(connectionString);
            if (!crmService.IsReady)
            {
                throw new Exception(crmService.LastError, crmService.LastException);
            }
            _service = crmService;
        }

        public IOrganizationService Service => _service;
    }
}
