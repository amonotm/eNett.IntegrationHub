using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.ClientIntegration
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

            foreach (var change in changes)
            {
                _messageBroker.PostChange(change);
            }
        }

        public void ReceiveChange(Change change)
        {
            switch (change.TableName)
            {
                case "Client":
                    _clientRepository.UpdateClient(change);
                    break;
                case "ClientContact":
                    _clientRepository.UpdateClientContact(change);
                    break;
                default:
                    throw new Exception(
                        string.Format("Client Integrator received a change for table '{0}' which was not expected",
                            change.TableName));
            }
        }

        private List<Change> GetClientChanges()
        {
            DateTime updateTime = _integrationRepository.GetUpdateTimeBySystemAndTableName("Client", "Client");

            return _clientRepository.GetClientChanges(updateTime);
        }

        private List<Change> GetClientContactChanges()
        {
            DateTime updateTime = _integrationRepository.GetUpdateTimeBySystemAndTableName("Client", "ClientContact");

            return _clientRepository.GetClientContactChanges(updateTime);
        }
    }
}
