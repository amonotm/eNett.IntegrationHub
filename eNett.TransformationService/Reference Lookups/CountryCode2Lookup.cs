using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class CountryCode2Lookup : ReferenceLookup
    {
        public CountryCode2Lookup(IReferenceRepository referenceRepository)
            : base(referenceRepository)
        {
            this.SourceSystemName = "Client";
            this.DestinationSystemName = "SalesForce";
            this.SourceTable = "Client";
            this.SourceColumn = "CountryID";
            this.DestinationTable = "Account";
            this.DestinationColumn = "countrycode2__c";
        }

        public override Field Apply(Field sourceField)
        {
            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = this.ReferenceRepository.GetCountryCode2ByCountryID(Convert.ToInt32(sourceField.Value));

            return destinationField;
        }
    }
}
