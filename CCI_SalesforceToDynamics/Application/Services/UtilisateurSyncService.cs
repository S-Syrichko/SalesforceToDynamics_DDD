using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.Mappers;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics.Application.Services
{
    public class UtilisateurSyncService
    {
        private readonly ISalesforceUserRepository _sfUserRepository;
        private readonly IDynamicsUserRepository _dynamicsUserRepository;

        public UtilisateurSyncService(ISalesforceUserRepository sfUserRepository, IDynamicsUserRepository dynamicsUserRepository)
        {
            _sfUserRepository = sfUserRepository;
            _dynamicsUserRepository = dynamicsUserRepository;
        }

        public async Task SyncUtilisateursAsync()
        {
            var sfUsers = await _sfUserRepository.GetAsync();

            foreach (var user in sfUsers)
            {
                var utilisateur = SfUserMapper.Map(user);
                UtilisateurDTO utilisateurDTO = DynUtilisateurMapper.Map(utilisateur);
                var utilisateurDynamics = _dynamicsUserRepository.Update(utilisateurDTO);
            }
        }
    }
}
