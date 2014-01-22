using eNett.IntegrationHub.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.TransformationService
{
    public abstract class ReferenceLookup : Transformation
    {        
        protected IReferenceRepository ReferenceRepository { get; set; }

        public ReferenceLookup(IReferenceRepository referenceRepository)
        {
            this.ReferenceRepository = referenceRepository;
        }
    }
}
