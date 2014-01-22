using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.TransformationService
{
    public class TransformationRepository : ITransformationRepository
    {
        public List<Mapping> GetMappingsBySystemsAndSourceTable(string sourceSystem, string destinationSystem,
            string sourceTable)
        {
            TransformationDBDataContext context = new TransformationDBDataContext();

            int sourceSystemId = context.SourceSystems.First(s => s.Name == sourceSystem).SourceSystemID;
            int destinationSystemId = context.SourceSystems.First(s => s.Name == destinationSystem).SourceSystemID;

            List<Mapping> mappings =
               context.Mappings.Where(
                   m => m.SourceSystemID == sourceSystemId
                       && m.DestinationSystemID == destinationSystemId
                       && m.SourceTableName == sourceTable).ToList();

            return mappings;
        }
    }
}
