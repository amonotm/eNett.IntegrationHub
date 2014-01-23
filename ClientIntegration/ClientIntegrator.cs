using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;
using eNett.IntegrationHub.SourceSystems.Client;

namespace ClientIntegration
{
    public class ClientIntegrator
    {
        private readonly IIntegrationRepository _integrationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMessageBroker _messageBroker;

        public ClientIntegrator(IIntegrationRepository integrationRepository, IClientRepository clientRepository, IMessageBroker messageBroker)
        {
            _integrationRepository = integrationRepository;
            _clientRepository = clientRepository;
            _messageBroker = messageBroker;
        }

        public void PostChanges()
        {
            var changes = GetClientChanges();

            changes.AddRange(GetClientContactChanges());
        }

        private List<Change> GetClientChanges()
        {
            DateTime updateTime = _integrationRepository.GetUpdateTimeBySystemAndTableName("Client", "Client");

            return _clientRepository.GetModifiedClients(updateTime);
        }

        private List<Change> GetClientContactChanges()
        {
            DateTime updateTime = _integrationRepository.GetUpdateTimeBySystemAndTableName("Client", "ClientContact");

            return _clientRepository.GetModifiedClients(updateTime);
        }
    }
}
