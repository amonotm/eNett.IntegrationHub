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

        List<Change> GetClientChanges(DateTime updateTime);

        List<Change> GetClientContactChanges(DateTime updateTime);

        void UpdateClient(Change change);

        void UpdateClientContact(Change change);
    }
}
