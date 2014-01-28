using System;
using System.Collections.Generic;
using eNett.IntegrationHub.SharedInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eNett.IntegrationHub.ClientIntegration;
using eNett.IntegrationHub.BusinessObjects;
using Moq;

namespace eNett.IntegrationHub.UnitTest
{
    [TestClass]
    public class ClientIntegratorTest
    {
        [TestMethod]
        public void ClientIntegrator_PostChanges()
        {
            var clientField1 = new Field {Name = "ECN", Value = 1};
            var clientField2 = new Field {Name = "LegalName", Value = "Test Company"};
            var clientChange = new Change
            {
                Fields = {clientField1, clientField2},
                SystemName = "Client",
                TableName = "Client"
            };

            var clientContactField1 = new Field {Name = "ECN", Value = 1};
            var clientContactField2 = new Field {Name = "Surname", Value = "Smith"};
            var clientContactChange = new Change
            {
                Fields = {clientContactField1, clientContactField2},
                SystemName = "Client",
                TableName = "ClientContact"
            };

            var mockIntegrationRepository = new Mock<IIntegrationRepository>();
            mockIntegrationRepository.Setup(i => i.GetUpdateTimeBySystemAndTableName("Client", "Client")).Returns(DateTime.Now);
            mockIntegrationRepository.Setup(i => i.GetUpdateTimeBySystemAndTableName("Client", "ClientContact")).Returns(DateTime.Now);

            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(c => c.GetClientChanges(It.IsAny<DateTime>()))
                .Returns(new List<Change> {clientChange});
            mockClientRepository.Setup(c => c.GetClientContactChanges(It.IsAny<DateTime>()))
                .Returns(new List<Change> {clientContactChange});

            var mockBrokerRepository = new Mock<IMessageBroker>();

            var clientIntegrator = new ClientIntegrator(mockIntegrationRepository.Object, mockClientRepository.Object,
                mockBrokerRepository.Object);

            clientIntegrator.PostChanges();

            mockBrokerRepository.Verify(b => b.PostChange(clientChange), Times.Once);
            mockBrokerRepository.Verify(b => b.PostChange(clientContactChange), Times.Once);
        }
    }
}
