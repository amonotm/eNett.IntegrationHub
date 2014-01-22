using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.SharedInterfaces
{
    public interface IReferenceRepository
    {
        string GetClientTypeByClientTypeID(int clientTypeID);
        string GetCountryNameByCountryID(int countryID);
        string GetCountryCode2ByCountryID(int countryID);
        string GetCountryCode3ByCountryID(int countryID);
    }
}
