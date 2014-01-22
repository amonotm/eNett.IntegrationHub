using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class CountryCode3Lookup : ReferenceLookup
    {
        public CountryCode3Lookup(IReferenceRepository referenceRepository)
            : base(referenceRepository)
        {
            this.SourceSystemName = "Client";
            this.DestinationSystemName = "SalesForce";
            this.SourceTable = "Client";
            this.SourceColumn = "CountryID";
            this.DestinationTable = "Account";
            this.DestinationColumn = "countrycode3__c";
        }

        public override Field Apply(Field sourceField)
        {
            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = this.ReferenceRepository.GetCountryCode3ByCountryID(Convert.ToInt32(sourceField.Value));

            return destinationField;
        }
    }
}
