using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;

namespace eNett.IntegrationHub.TransformationService
{
    public abstract class Lookup : Transformation
    {
        protected Field ApplyLookup(Field sourceField, Func<int, object> lookupMehod, TransformationException.Action failAction)
        {
            int lookupValue;

            if (sourceField.Value == null)
            {
                return new Field { Name = this.DestinationColumn, Value = null };
            }

            if (!Int32.TryParse(sourceField.Value.ToString(), out lookupValue))
            {
                throw new TransformationException(
                    string.Format("Lookup {0} failed: '{1}' cannot be converted to an integer", this.GetType().Name,
                        sourceField.Value), failAction);
            }

            var destinationField = new Field { Name = this.DestinationColumn };

            destinationField.Value = lookupMehod.Invoke(lookupValue);

            if (destinationField.Value == null || destinationField.Value.ToString() == string.Empty)
            {
                throw new TransformationException(
                    string.Format("Lookup {0} failed: value '{1}' does not exist", this.GetType().Name,
                        sourceField.Value), failAction);
            }

            return destinationField;
        }
    }
}
