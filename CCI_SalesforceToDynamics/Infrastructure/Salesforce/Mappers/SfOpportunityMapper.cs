using CCI_SalesforceToDynamics.Domain.Entities;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.SOQL;
using System;
using System.Collections.Generic;

namespace CCI_SalesforceToDynamics.Infrastructure.Salesforce.Mappers
{
    public static class SfOpportunityMapper
    {
        public static Proposition Map(OpportunitySOQL opportunity, ContactSOQL sfContact, AccountSOQL sfAccount, List<PrestationSOQL> sfPrestations = null, List<OpportunityLineSOQL> sfOppoLine = null)
        {
            List<ProduitDeProposition> produitsDeProposition = new List<ProduitDeProposition>();

            if (sfPrestations != null)
            {

                foreach (var prestation in sfPrestations)
                {
                    produitsDeProposition.Add(SfProductMapper.Map(prestation));
                }

            }
            else if (sfOppoLine != null)
            {

                foreach (var oppoLine in sfOppoLine)
                {
                    produitsDeProposition.Add(SfProductMapper.Map(oppoLine));
                }
            }

            Contact contact = SfContactMapper.Map(sfContact);
            Compte compte = SfAccountMapper.Map(sfAccount);
            contact.CarteDeVisite = SfVisitCardMapper.Map(sfContact);

            return new Proposition()
            {
                IdentifiantSalesforce = opportunity.Id,
                Titre = opportunity.Name,
                DateProposition = DateTime.Parse(opportunity.CreatedDate),
                DivisionCCI = GetCirconscriptionFromZipCode(sfAccount.ShippingPostalCode),
                Produits = produitsDeProposition,
                Contact = contact,
                Compte = compte,
                Proprietaire = opportunity.OwnerId
            };
        }

        static string GetCirconscriptionFromZipCode(string zipCode)
        {
            string circonscription = "CCI Bourgogne Franche-Comté";

            if (!String.IsNullOrEmpty(zipCode))
            {
                if (zipCode.Replace(".0", "").Replace(" ", "").Length == 5)
                {
                    switch (zipCode.Substring(0, 2))
                    {
                        case "21":
                            circonscription = "CCI Côte-d'Or ∙ Saône-et-Loire";
                            break;
                        case "71":
                            circonscription = "CCI Côte-d'Or ∙ Saône-et-Loire";
                            break;
                        case "70":
                            circonscription = "CCI Saône-Doubs";
                            break;
                        case "25":
                            circonscription = "CCI Saône-Doubs";
                            break;
                        case "39":
                            circonscription = "CCI Jura";
                            break;
                        case "90":
                            circonscription = "CCI Territoire de Belfort";
                            break;
                        case "58":
                            circonscription = "CCI Nièvre";
                            break;
                        case "89":
                            circonscription = "CCI Yonne";
                            break;
                        default:
                            circonscription = "CCI Bourgogne Franche-Comté";
                            break;
                    }
                }
            }

            return circonscription;
        }
    }
}
