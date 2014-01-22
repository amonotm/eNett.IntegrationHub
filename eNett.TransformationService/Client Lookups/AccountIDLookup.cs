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
            int ecn;

            if (!Int32.TryParse(sourceField.Value, out ecn))
            {
                throw new Exception(
                    string.Format("Lookup AccountTDLookup failed: '{0}' cannot be converted to an integer",
                        sourceField.Value));
            }

            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = this.ClientRepository.GetSalesForceIDByECN(Convert.ToInt32(ecn));

            if (destinationField.Value == string.Empty)
            {
                throw new TransformationException(
                    string.Format("Lookup AccountIDLookup failed: value '{0}' does not exist",
                        sourceField.Value), TransformationException.Action.Fail);
            }

            return destinationField;
        }
    }
}
