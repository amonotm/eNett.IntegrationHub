using eNett.IntegrationHub.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.SharedInterfaces
{
    public interface IClientRepository
    {
        string GetSalesForceIDByECN(int ecn);

        List<Change> GetModifiedClients(DateTime updateTime);

        List<Change> GetModifiedClientContacts(DateTime updateTime);
    }
}
