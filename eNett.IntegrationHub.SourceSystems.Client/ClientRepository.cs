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

        public List<Change> GetClientChanges(DateTime updateTime)
        {
            var changes = new List<Change>();
            var context = new ClientDBDataContext();

            var changedClients =
                context.Clients.Where(c => !c.LastModifiedDate.HasValue || c.LastModifiedDate > updateTime);

            foreach (var client in changedClients)
            {
                changes.Add(new Change(client, "Client", "Client"));
            }

            return changes;
        }

        public List<Change> GetClientContactChanges(DateTime updateTime)
        {
            var changes = new List<Change>();
            var context = new ClientDBDataContext();

            var changedClientsContacts =
                context.ClientContacts.Where(c => !c.LastModifiedDate.HasValue || c.LastModifiedDate > updateTime);

            foreach (var client in changedClientsContacts)
            {
                changes.Add(new Change(client, "ClientContact", "Client"));
            }

            return changes;
        }        

        public void UpdateClient(Change change)
        {
            var context = new ClientDBDataContext();
            
            int ecn = (int)change.Fields.First(f => f.Name == "ECN").Value;

            if (context.Clients.Any(c => c.ECN == ecn))
            {
                var client = context.Clients.First(c => c.ECN == ecn);

                change.LoadObject(client);

                context.SubmitChanges();
            }
            else
            {
                throw new Exception(
                    string.Format("No Client exists with ECN '{0}' and inserting new Clients is not yet supported",
                        ecn));
            }
        }

        public void UpdateClientContact(Change change)
        {
            var context = new ClientDBDataContext();

            int clientContactID = (int)change.Fields.First(f => f.Name == "ClientContactID").Value;

            if (context.ClientContacts.Any(c => c.ClientContactID == clientContactID))
            {
                var clientContact = context.ClientContacts.First(c => c.ClientContactID == clientContactID);

                change.LoadObject(clientContact);

                context.SubmitChanges();
            }
            else
            {
                throw new Exception(
                    string.Format(
                        "No ClientContact exists with ClientContactID '{0}' and inserting new ClientContacts is not yet supported",
                        clientContactID));
            }
        }
    }
}
