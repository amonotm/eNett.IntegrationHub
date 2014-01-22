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
            int countryID;

            if (!Int32.TryParse(sourceField.Value, out countryID))
            {
                throw new Exception(
                    string.Format("Lookup CountryNameLookup failed: '{0}' cannot be converted to an integer",
                        sourceField.Value));
            }

            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value =
                this.ReferenceRepository.GetCountryNameByCountryID(Convert.ToInt32(sourceField.Value));

            return destinationField;
        }
    }
}
