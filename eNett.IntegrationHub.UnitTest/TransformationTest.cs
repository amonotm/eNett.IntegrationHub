using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.TransformationService;
using Moq;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.UnitTest
{
    [TestClass]
    public class TransformationTest
    {        
        [TestMethod]
        public void Transformer_Transform_MappingTest()
        {
            string sourceSystem = "Client";
            string destinationSystem = "SalesForce";
            string sourceTableName = "Client";
            string destinationTableName = "Account";
            string sourceColumnName = "LegalName";
            string destinationColumnName = "Legal_Name__c";
            string value = "Test Company";            

            var mapping = new Mapping
            {
                SourceTableName = sourceTableName,
                DestinationTableName = destinationTableName,
                SourceColumnName = sourceColumnName,
                DestinationColumnName = destinationColumnName
            };

            var mappings = new List<Mapping> {mapping};

            Transformer transformer =
                new Transformer(SetupMockTransformationRepository(mappings, sourceSystem, destinationSystem, sourceTableName),
                    setupMockReferenceRepository("Corporate"), null, new UnitTestLogger());

            Change change = new Change();
            change.TableName = sourceTableName;
            change.Fields.Add(new Field { Name = sourceColumnName, Value = value });            

            var result = transformer.Transform(change, sourceSystem, destinationSystem, sourceTableName);

            Change expectedChange = new Change();
            expectedChange.TableName = destinationTableName;
            expectedChange.Fields.Add(new Field { Name = destinationColumnName, Value = value });

            Assert.IsNotNull(result);
            Assert.AreEqual(destinationTableName, result.TableName);
            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(1, result.Fields.Count);
            Assert.AreEqual(destinationColumnName, result.Fields.First().Name);
            Assert.AreEqual(expectedChange.Fields.First().Value, result.Fields.First().Value);
        }

        [TestMethod]
        public void Transformer_Transform_TransformTest()
        {
            string sourceSystem = "Client";
            string destinationSystem = "SalesForce";
            string sourceTableName = "Client";
            string destinationTableName = "Account";
            string sourceColumnName = "ClientStatusID";
            string destinationColumnName = "Client_Type_Description__c";
            string sourceValue = "9";
            string destinationValue = "Corporate";

            Transformer transformer =
                new Transformer(SetupMockTransformationRepository(new List<Mapping>(), sourceSystem, destinationSystem, sourceTableName),
                    setupMockReferenceRepository(destinationValue), null, new UnitTestLogger());

            Change change = new Change();
            change.TableName = sourceTableName;
            change.Fields.Add(new Field { Name = sourceColumnName, Value = sourceValue });

            var result = transformer.Transform(change, sourceSystem, destinationSystem, sourceTableName);

            Change expectedChange = new Change();
            expectedChange.TableName = destinationTableName;
            expectedChange.Fields.Add(new Field { Name = destinationColumnName, Value = destinationValue });

            Assert.IsNotNull(result);
            Assert.AreEqual(destinationTableName, result.TableName);
            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(1, result.Fields.Count);
            Assert.AreEqual(destinationColumnName, result.Fields.First().Name);
            Assert.AreEqual(expectedChange.Fields.First().Value, result.Fields.First().Value);
        }

        [TestMethod]
        public void Transformer_Transform_TransformTest_BadParameter()
        {
            string sourceSystem = "Client";
            string destinationSystem = "SalesForce";
            string sourceTableName = "Client";
            string sourceColumnName = "ClientStatusID";
            string value = "a";

            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.Log(It.IsAny<string>()));            

            Transformer transformer =
                new Transformer(SetupMockTransformationRepository(new List<Mapping>(), sourceSystem, destinationSystem, sourceTableName),
                    setupMockReferenceRepository("Corporate"), null, mockLogger.Object);

            Change change = new Change();
            change.TableName = sourceTableName;
            change.Fields.Add(new Field { Name = sourceColumnName, Value = value });

            var result = transformer.Transform(change, sourceSystem, destinationSystem, sourceTableName);

            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Transformer_Transform_TransformTest_LookupValueNotFound()
        {
            string sourceSystem = "Client";
            string destinationSystem = "SalesForce";
            string sourceTableName = "Client";
            string sourceColumnName = "ClientStatusID";
            string value = "9999999";

            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.Log(It.IsAny<string>()));

            var mockReferenceRepository = new Mock<IReferenceRepository>();
            mockReferenceRepository.Setup(c => c.GetClientTypeByClientTypeID(It.IsAny<int>())).Returns(string.Empty);

            Transformer transformer =
                new Transformer(SetupMockTransformationRepository(new List<Mapping>(), sourceSystem, destinationSystem, sourceTableName),
                    mockReferenceRepository.Object, null, mockLogger.Object);

            Change change = new Change();
            change.TableName = sourceTableName;
            change.Fields.Add(new Field { Name = sourceColumnName, Value = value });

            var result = transformer.Transform(change, sourceSystem, destinationSystem, sourceTableName);

            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }

        private ITransformationRepository SetupMockTransformationRepository(List<Mapping> mappings, string sourceSystem, string destinationSystem, string sourceTableName)
        {
            var mockTransformationRepository = new Mock<ITransformationRepository>();
            mockTransformationRepository.Setup(
                t => t.GetMappingsBySystemsAndSourceTable(sourceSystem, destinationSystem, sourceTableName))
                .Returns(mappings);

            return mockTransformationRepository.Object;
        }

        private IReferenceRepository setupMockReferenceRepository(string clientType)
        {
            var mockReferenceRepository = new Mock<IReferenceRepository>();
            mockReferenceRepository.Setup(c => c.GetClientTypeByClientTypeID(It.IsAny<int>())).Returns(clientType);

            return mockReferenceRepository.Object;
        }
    }
}
