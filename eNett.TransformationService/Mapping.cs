using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;

namespace eNett.IntegrationHub.TransformationService
{
    public partial class Mapping : Transformation
    {
        public override string SourceSystemName
        {
            get { return this.SourceSystem.Name; }
        }

        public override string DestinationSystemName
        {
            get { return this.DestinationSystem.Name; }
        }

        public override string SourceTable
        {
            get { return this.SourceTableName; }
        }

        public override string DestinationTable
        {
            get { return this.DestinationTableName; }
        }

        public override string DestinationColumn
        {
            get { return this.DestinationColumnName; }
        }

        public override string SourceColumn { get { return this.SourceColumnName; } }

        public override Field Apply(Field sourceField)
        {
            return new Field {Name = this.DestinationColumnName, Value = sourceField.Value};
        }
    }
}
