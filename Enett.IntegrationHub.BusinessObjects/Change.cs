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
                if (!property.PropertyType.FullName.Contains("eNett"))              // ensure that custom types are not sent in the change as receiver may not reference it
                {
                    var value = property.GetValue(sourceObject);

                    Fields.Add(new Field { Name = property.Name, Value = value });   
                }
            }
        }

        public void LoadObject<T>(T destinationObject)
        {
            foreach (var field in this.Fields)
            {
                 var property = destinationObject.GetType().GetProperty(field.Name);

                if (property != null)
                {
                    property.SetValue(destinationObject, field.Value);
                }
                else
                {
                    throw new Exception("Property {0} on mapped object {1} does not exist on actual object. Ensure mapping is up to date.");
                }
            }
        }

        public string TableName { get; set; }
        public string SystemName { get; set; }

        public List<Field> Fields { get; set; }
    }
}
