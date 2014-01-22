using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.TransformationService
{
    public class TransformationException : Exception
    {
        public TransformationException(string message, Action suggestedAction) : base(message)
        {
            this.SuggestedAction = suggestedAction;
        }

        public Action SuggestedAction { get; set; }

        public enum Action
        {
            Fail,
            Log
        }
    }
}
