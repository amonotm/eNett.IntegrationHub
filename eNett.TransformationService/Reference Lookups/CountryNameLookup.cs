using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class CountryNameLookup : ReferenceLookup
    {
        public CountryNameLookup(IReferenceRepository referenceRepository) : base(referenceRepository)
        {
            this.SourceSystemName = "Client";
            this.DestinationSystemName = "SalesForce";
            this.SourceTable = "Client";
            this.SourceColumn = "CountryID";
            this.DestinationTable = "Account";
            this.DestinationColumn = "Country_name__c";
        }

        public override Field Apply(Field sourceField)
        {
            return this.ApplyLookup(sourceField, this.ReferenceRepository.GetCountryNameByCountryID,
                TransformationException.Action.Log);
        }
    }
}
