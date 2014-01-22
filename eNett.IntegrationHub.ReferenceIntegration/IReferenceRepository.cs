using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.ReferenceIntegration
{
    public interface IReferenceRepository
    {
        string GetClientTypeByClientTypeID(int clientTypeID);
    }
}
