using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.SourceSystems.Reference
{
    public class ReferenceRepository : IReferenceRepository
    {
        public string GetClientTypeByClientTypeID(int clientTypeID)
        {
            var context = new ReferenceDBDataContext();

            var clientType = context.ClientTypes.FirstOrDefault(ct => ct.ClientTypeID == clientTypeID);

            return clientType != null ? clientType.ClientTypeName : null;
        }

        public string GetCountryNameByCountryID(int countryID)
        {
            var context = new ReferenceDBDataContext();

            var country = context.Countries.FirstOrDefault(c => c.CountryID == countryID);

            return country != null ? country.CountryName : null;
        }

        public string GetCountryCode2ByCountryID(int countryID)
        {
            var context = new ReferenceDBDataContext();

            var country = context.Countries.FirstOrDefault(c => c.CountryID == countryID);

            return country != null ? country.CountryCode2 : null;
        }

        public string GetCountryCode3ByCountryID(int countryID)
        {
            var context = new ReferenceDBDataContext();

            var country = context.Countries.FirstOrDefault(c => c.CountryID == countryID);

            return country != null ? country.CountryCode3 : null;
        }
    }
}
