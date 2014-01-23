using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.SharedInterfaces;
using eNett.IntegrationHub.BusinessObjects;

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

        public List<Change> GetModifiedClients(DateTime updateTime)
        {
            var context = new ClientDBDataContext();

            var changedClients =
                context.Clients.Where(c => !c.LastModifiedDate.HasValue || c.LastModifiedDate > updateTime);

            foreach (var client in changedClients)
            {
                
            }
        }
    }
}
