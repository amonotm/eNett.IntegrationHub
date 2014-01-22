using System;
using eNett.IntegrationHub.SourceSystems.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using eNett.IntegrationHub.SourceSystems.Reference;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.TransformationService;

namespace eNett.IntegrationHub.IntegrationTest
{
    [TestClass]
    public class TransformationTest
    {
        [TestMethod]
        public void Transformer_Transform_ClientSystemTest_ClientTable()
        {
            Change change = new Change();
            change.TableName = "Client";
            change.Fields.Add(new Field { Name = "LegalName", Value = "Test Company" });
            change.Fields.Add(new Field { Name = "TradingAs", Value = "Test Company 1" });
            change.Fields.Add(new Field { Name = "ClientStatusID", Value = "9" });
            change.Fields.Add(new Field { Name = "CountryID", Value = "36" });

            Transformer transformer = new Transformer(new TransformationRepository(), new ReferenceRepository(), new ClientRepository(), null);

            var result = transformer.Transform(change, "Client", "SalesForce", "Client");

            Change expectedChange = new Change();
            expectedChange.TableName = "Account";
            expectedChange.Fields.Add(new Field { Name = "Legal_Name__c", Value = "Test Company" });
            expectedChange.Fields.Add(new Field { Name = "Trading_As__c", Value = "Test Company 1" });
            expectedChange.Fields.Add(new Field { Name = "Client_Type_Description__c", Value = "Corporate" });
            expectedChange.Fields.Add(new Field { Name = "Country_name__c", Value = "AUSTRALIA" });
            expectedChange.Fields.Add(new Field { Name = "countrycode2__c", Value = "AU" });
            expectedChange.Fields.Add(new Field { Name = "countrycode3__c", Value = "AUS" });

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedChange.TableName, result.TableName);
            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(expectedChange.Fields.Count, result.Fields.Count);

            foreach (var expectedfield in expectedChange.Fields)
            {
                Assert.AreEqual(1, result.Fields.Count(f => f.Name == expectedfield.Name));

                var resultField = result.Fields.First(f => f.Name == expectedfield.Name);

                Assert.AreEqual(expectedfield.Value, resultField.Value);
            }
        }

        [TestMethod]
        public void Transformer_Transform_ClientSystemTest_ClientContactTable()
        {
            Change change = new Change();
            change.TableName = "ClientContact";
            change.Fields.Add(new Field { Name = "Title", Value = "Mrs" });
            change.Fields.Add(new Field { Name = "GivenName", Value = "Toni" });
            change.Fields.Add(new Field { Name = "Surname", Value = "Vasicyo" });
            change.Fields.Add(new Field { Name = "Position", Value = "Owner" });
            change.Fields.Add(new Field { Name = "Email", Value = "prakash.patel@cognizant.com" });
            change.Fields.Add(new Field { Name = "Phone", Value = "61-2-3279-9144" });
            change.Fields.Add(new Field { Name = "Fax", Value = "61-2-1111-1111" });
            change.Fields.Add(new Field { Name = "Mobile", Value = "0412 345 678" });
            change.Fields.Add(new Field { Name = "ECN", Value = "100011" });

            Transformer transformer = new Transformer(new TransformationRepository(), new ReferenceRepository(), new ClientRepository(), null);

            var result = transformer.Transform(change, "Client", "SalesForce", "ClientContact");

            Change expectedChange = new Change();
            expectedChange.TableName = "Contact";
            expectedChange.Fields.Add(new Field { Name = "Salutation", Value = "Mrs" });
            expectedChange.Fields.Add(new Field { Name = "FirstName", Value = "Toni" });
            expectedChange.Fields.Add(new Field { Name = "LastName", Value = "Vasicyo" });
            expectedChange.Fields.Add(new Field { Name = "Title", Value = "Owner" });
            expectedChange.Fields.Add(new Field { Name = "Email", Value = "prakash.patel@cognizant.com" });
            expectedChange.Fields.Add(new Field { Name = "Phone", Value = "61-2-3279-9144" });
            expectedChange.Fields.Add(new Field { Name = "Fax", Value = "61-2-1111-1111" });
            expectedChange.Fields.Add(new Field { Name = "MobilePhone", Value = "0412 345 678" });
            expectedChange.Fields.Add(new Field { Name = "AccountId", Value = "0019000000NeWbdAAF" });

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedChange.TableName, result.TableName);
            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(expectedChange.Fields.Count, result.Fields.Count);

            foreach (var expectedfield in expectedChange.Fields)
            {
                Assert.AreEqual(1, result.Fields.Count(f => f.Name == expectedfield.Name));

                var resultField = result.Fields.First(f => f.Name == expectedfield.Name);

                Assert.AreEqual(expectedfield.Value, resultField.Value);
            }
        }
    }
}
