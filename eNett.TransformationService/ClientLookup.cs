using eNett.IntegrationHub.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.TransformationService
{
    public abstract class ClientLookup : Transformation
    {        
        protected IClientRepository ClientRepository { get; set; }

        public ClientLookup(IClientRepository clientRepository)
        {
            this.ClientRepository = clientRepository;
        }
    }
}
