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

        public string TableName { get; set; }

        public List<Field> Fields { get; set; }
    }
}
