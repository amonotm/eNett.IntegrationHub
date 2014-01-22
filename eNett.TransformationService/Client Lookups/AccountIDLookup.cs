using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class AccountIDLookup : ClientLookup
    {
        public AccountIDLookup(IClientRepository clientRepository)
            : base(clientRepository)
        {
            this.SourceSystemName = "Client";
            this.DestinationSystemName = "SalesForce";
            this.SourceTable = "ClientContact";
            this.SourceColumn = "ECN";
            this.DestinationTable = "Contact";
            this.DestinationColumn = "AccountId";
        }

        public override Field Apply(Field sourceField)
        {
            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = this.ClientRepository.GetSalesForceIDByECN(Convert.ToInt32(sourceField.Value));

            return destinationField;
        }
    }
}
