using System;
using System.Collections.Generic;
using System.Linq;
using eNett.IntegrationHub.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eNett.IntegrationHub.UnitTest
{
    [TestClass]
    public class BusinessObjectTest
    {
        [TestMethod]
        public void BusinessObjects_Change_Constructor_FromObject()
        {
            string sourceSystem = "SourceSystem";
            string sourceTable = "SourceTable";
            var testObject = new TestObject {TestProperty1 = "Val1", TestProperty2 = 1, TestProperty3 = null};

            var result = new Change(testObject, sourceTable, sourceSystem);

            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(3, result.Fields.Count);            
        }

        [TestMethod]
        public void BusinessObjects_Change_LoadObject()
        {
            string sourceSystem = "SourceSystem";
            string sourceTable = "SourceTable";

            var fields = new List<Field>
            {
                new Field {Name = "TestProperty1", Value = "Val1"},
                new Field {Name = "TestProperty2", Value = 1},
                new Field {Name = "TestProperty3", Value = null}
            };

            var change = new Change {Fields = fields, SystemName = sourceSystem, TableName = sourceTable};

            var result = new TestObject();

            change.LoadObject(result);

            Assert.AreEqual(fields.First(f => f.Name == "TestProperty1").Value, result.TestProperty1);
            Assert.AreEqual(fields.First(f => f.Name == "TestProperty2").Value, result.TestProperty2);
            Assert.AreEqual(fields.First(f => f.Name == "TestProperty3").Value, result.TestProperty3);
        }

        private class TestObject
        {
            public string TestProperty1 { get; set; }
            public int TestProperty2 { get; set; }
            public DateTime? TestProperty3 { get; set; }
            protected string HiddenField = "Val";
        }
    }
}
