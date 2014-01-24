using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.BusinessObjects
{
    public class Change
    {
        public Change()
        {
            Fields = new List<Field>();
        }

        public Change(object sourceObject, string tableName, string systemName)
        {
            Fields = new List<Field>();
            TableName = tableName;
            SystemName = systemName;

            foreach (var property in sourceObject.GetType().GetProperties())
            {
                var value = property.GetValue(sourceObject);                

                Fields.Add(new Field {Name = property.Name, Value = value });
            }
        }

        public string TableName { get; set; }
        public string SystemName { get; set; }

        public List<Field> Fields { get; set; }
    }
}
