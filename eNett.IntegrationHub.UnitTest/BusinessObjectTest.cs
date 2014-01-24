using System;
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

            var change = new Change(testObject, sourceTable, sourceSystem);

            Assert.IsNotNull(change.Fields);
            Assert.AreEqual(change.Fields.Count, 3);            
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
