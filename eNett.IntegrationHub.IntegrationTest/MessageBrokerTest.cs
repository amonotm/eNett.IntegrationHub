using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.Messaging;

namespace eNett.IntegrationHub.IntegrationTest
{
    [TestClass]
    public class MessageBrokerTest
    {
        [TestMethod]
        public void MessageBroker_Publish()
        {
            var clientField1 = new Field {Name = "ECN", Value = 1};
            var clientField2 = new Field {Name = "LegalName", Value = "Test Company"};
            var clientChange = new Change
            {
                Fields = {clientField1, clientField2},
                SystemName = "Client",
                TableName = "Client"
            };

            var messageBroker = new MessageBroker();

            messageBroker.PostChange(clientChange);
        }
    }
}
