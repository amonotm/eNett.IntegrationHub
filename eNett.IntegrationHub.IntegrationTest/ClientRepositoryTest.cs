using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eNett.IntegrationHub.SourceSystems.Client;

namespace eNett.IntegrationHub.IntegrationTest
{
    [TestClass]
    public class ClientRepositoryTest
    {
        [TestMethod]
        public void ClientRepository_GetModifiedClients()
        {
            var repository = new ClientRepository();

            var changes = repository.GetClientChanges(DateTime.Parse("2013-11-13 00:00:00.000"));

            Assert.AreNotSame(0, changes.Count);
            Assert.AreEqual(47, changes.First().Fields.Count);
        }

        [TestMethod]
        public void ClientRepository_GetModifiedClientContacts()
        {
            var repository = new ClientRepository();

            var changes = repository.GetClientContactChanges(DateTime.Parse("2013-11-13 00:00:00.000"));

            Assert.AreNotSame(0, changes.Count);
            Assert.AreEqual(14, changes.First().Fields.Count);
        }
    }
}
