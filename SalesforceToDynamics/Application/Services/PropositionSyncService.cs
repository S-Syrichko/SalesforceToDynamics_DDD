using SalesforceToDynamics.Domain.Entities;
using SalesforceToDynamics.Domain.Repositories;
using SalesforceToDynamics.Infrastructure.Dynamics.DTO;
using SalesforceToDynamics.Infrastructure.Dynamics.Mappers;
using SalesforceToDynamics.Infrastructure.Salesforce.Mappers;
using System;
using System.Threading.Tasks;

namespace SalesforceToDynamics.Application.Services
{
    public class PropositionSyncService
    {
        private readonly ISalesforceOpportunityRepository _sfOpportunityRepository;
        private readonly ISalesforcePrestationRepository _sfPrestationRepository;
        private readonly ISalesforceOpportunityLineRepository _sfOpportunityLineRepository;
        private readonly ISalesforceContactRepository _sfContactRepository;
        private readonly ISalesforceAccountRepository _sfAccountRepository;
        private readonly IDynamicsNAFCodeRepository _dynamicsNAFCodeRepository;
        private readonly IDynamicsDivisionRepository _dynamicsDivisionRepository;
        private readonly IDynamicsTeamRepository _dynamicsTeamRepository;
        private readonly IDynamicsAccountRepository _dynamicsAccountRepository;
        private readonly IDynamicsContactRepository _dynamicsContactRepository;
        private readonly IDynamicsUserRepository _dynamicsUserRepository;
        private readonly IDynamicsVisitCardRepository _dynamicsVisitCardRepository;
        private readonly IDynamicsPropositionRepository _dynamicsPropositionRepository;
        private readonly IDynamicsPropositionProductRepository _dynamicsPropositionProductRepository;

        public PropositionSyncService(ISalesforceOpportunityRepository sfOpportunityRepository,
            ISalesforcePrestationRepository sfPrestationRepository,
            ISalesforceOpportunityLineRepository sfOpportunityLineRepository,
            ISalesforceContactRepository sfContactRepository,
            ISalesforceAccountRepository sfAccountRepository,
            IDynamicsNAFCodeRepository dynamicsNAFCodeRepository,
            IDynamicsDivisionRepository dynamicsDivisionRepository,
            IDynamicsTeamRepository dynamicsTeamRepository,
            IDynamicsAccountRepository dynamicsAccountRepository,
            IDynamicsContactRepository dynamicsContactRepository,
            IDynamicsUserRepository dynamicsUserRepository,
            IDynamicsVisitCardRepository dynamicsVisitCardRepository,
            IDynamicsPropositionRepository dynamicsPropositionRepository,
            IDynamicsPropositionProductRepository dynamicsPropositionProductRepository
            )
        {
            _sfOpportunityRepository = sfOpportunityRepository;
            _sfPrestationRepository = sfPrestationRepository;
            _sfOpportunityLineRepository = sfOpportunityLineRepository;
            _sfContactRepository = sfContactRepository;
            _sfAccountRepository = sfAccountRepository;
            _dynamicsNAFCodeRepository = dynamicsNAFCodeRepository;
            _dynamicsDivisionRepository = dynamicsDivisionRepository;
            _dynamicsTeamRepository = dynamicsTeamRepository;
            _dynamicsAccountRepository = dynamicsAccountRepository;
            _dynamicsContactRepository = dynamicsContactRepository;
            _dynamicsUserRepository = dynamicsUserRepository;
            _dynamicsVisitCardRepository = dynamicsVisitCardRepository;
            _dynamicsPropositionRepository = dynamicsPropositionRepository;
            _dynamicsPropositionProductRepository = dynamicsPropositionProductRepository;
        }

        public async Task SyncPropositionsAsync()
        {
            var sfOpportunities = await _sfOpportunityRepository.GetAsync();

            foreach (var opportunity in sfOpportunities)
            {
                var sfContact = await _sfContactRepository.GetByIdAsync(opportunity.Contact_opportunite__c);
                var sfAccount = await _sfAccountRepository.GetByIdAsync(opportunity.AccountId);

                Proposition proposition = new Proposition();
                var sfPrestations = await _sfPrestationRepository.GetByOpportunityIdAsync(opportunity.Id);

                if (sfPrestations.Count == 0)
                {
                    var sfOppoLines = await _sfOpportunityLineRepository.GetByOpportunityIdAsync(opportunity.Id);
                    proposition = SfOpportunityMapper.Map(opportunity, sfContact, sfAccount, null, sfOppoLines);
                }
                else
                {
                    proposition = SfOpportunityMapper.Map(opportunity, sfContact, sfAccount, sfPrestations);
                }

                Guid businessUnitId = _dynamicsDivisionRepository.GetGuidByName(proposition.DivisionCCI);
                Guid ownerTeamId = _dynamicsTeamRepository.GetGuidByDivisionReference(businessUnitId);
                Guid nafCodeId = _dynamicsNAFCodeRepository.GetGuidByCode(proposition.Compte.CodeNaf);

                CompteDTO compte = DynCompteMapper.Map(proposition.Compte, nafCodeId, ownerTeamId);
                ContactDTO contact = DynContactMapper.Map(proposition.Contact);

                Guid accountId = _dynamicsAccountRepository.CreateUpdate(compte);
                Guid contactId = _dynamicsContactRepository.CreateUpdate(contact);
                Guid ownerId = _dynamicsUserRepository.GetBySalesforceId(proposition.Proprietaire);

                CarteDeVisiteDTO carteDeVisite = DynCarteDeVisiteMapper.Map(proposition.Contact.CarteDeVisite, contactId, accountId);
                Guid visitCardId = _dynamicsVisitCardRepository.CreateUpdate(carteDeVisite);

                PropositionDTO propositionDTO = DynPropositionMapper.Map(proposition, visitCardId, accountId, ownerId, businessUnitId);
                Guid propositionId = _dynamicsPropositionRepository.CreateUpdate(propositionDTO);

                foreach (ProduitDeProposition product in proposition.Produits)
                {
                    ProduitDePropositionDTO propositionLine = DynLigneDePropositionMapper.Map(product, propositionId);
                    Guid productId = _dynamicsPropositionProductRepository.CreateUpdate(propositionLine);
                }

            }
        }
    }
}
