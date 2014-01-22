using System.Collections.Generic;

namespace eNett.IntegrationHub.TransformationService
{
    public interface ITransformationRepository
    {
        List<Mapping> GetMappingsBySystemsAndSourceTable(string sourceSystem, string destinationSystem,
            string sourceTable);
    }
}