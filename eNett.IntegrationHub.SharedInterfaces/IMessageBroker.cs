using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eNett.IntegrationHub.BusinessObjects;

namespace eNett.IntegrationHub.SharedInterfaces
{
    public interface IMessageBroker
    {
        void PostChange(Change change);
        void Start();
        void Subscribe(Action<Change> action, string sourceSystem);
    }
}
