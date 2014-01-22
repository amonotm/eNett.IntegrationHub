using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;

namespace eNett.IntegrationHub.TransformationService
{
    public abstract class Transformation
    {
        public virtual string SourceSystemName { get; set; }
        public virtual string DestinationSystemName { get; set; }
        public virtual string SourceTable { get; set; }  
        public virtual string SourceColumn { get; set; }
        public virtual string DestinationTable { get; set; }
        public virtual string DestinationColumn { get; set; }   

        public abstract Field Apply(Field sourceField);
    }
}
