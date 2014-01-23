using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class ClientTypeLookup : ReferenceLookup
    {
        public ClientTypeLookup(IReferenceRepository referenceRepository)
            : base(referenceRepository)
        {
            this.SourceSystemName = "Client";
            this.DestinationSystemName = "SalesForce";
            this.SourceTable = "Client";
            this.SourceColumn = "ClientStatusID";
            this.DestinationTable = "Account";
            this.DestinationColumn = "Client_Type_Description__c";
        }

        public override Field Apply(Field sourceField)
        {
            int clientTypeID;

            if (!Int32.TryParse(sourceField.Value, out clientTypeID))
            {
                throw new TransformationException(
                    string.Format("Lookup ClientTypeLookup failed: '{0}' cannot be converted to an integer",
                        sourceField.Value), TransformationException.Action.Log);
            }

            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = this.ReferenceRepository.GetClientTypeByClientTypeID(Convert.ToInt32(sourceField.Value));

            if (destinationField.Value == string.Empty)
            {
                throw new TransformationException(
                    string.Format("Lookup ClientTypeLookup failed: value '{0}' does not exist",
                        sourceField.Value), TransformationException.Action.Log);
            }

            return destinationField;
        }
    }
}
