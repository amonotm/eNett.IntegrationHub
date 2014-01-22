using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.SourceSystems.Client
{
    public class ClientRepository : IClientRepository
    {
        public string GetSalesForceIDByECN(int ecn)
        {
            var context = new ClientDBDataContext();

            var client = context.Clients.FirstOrDefault(c => c.ECN == ecn);

            return client != null ? client.SalesForceId : null;
        }
    }
}
