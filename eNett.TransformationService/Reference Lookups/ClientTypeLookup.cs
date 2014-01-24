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
            this.SourceColumn = "ClientTypeID";
            this.DestinationTable = "Account";
            this.DestinationColumn = "Client_Type_Description__c";
        }

        public override Field Apply(Field sourceField)
        {
            return this.ApplyLookup(sourceField, this.ReferenceRepository.GetClientTypeByClientTypeID,
                TransformationException.Action.Log);
        }
    }
}
