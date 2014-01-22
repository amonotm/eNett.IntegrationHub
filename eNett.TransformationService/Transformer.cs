using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.BusinessObjects;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.TransformationService
{
    public class Transformer
    {
        private readonly ITransformationRepository _transformationRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly List<Transformation> _transformations;
        private readonly ILogger _logger;

        public Transformer(ITransformationRepository transformationRepository, IReferenceRepository referenceRepository, IClientRepository clientRepository, ILogger logger)
        {
            this._transformationRepository = transformationRepository;
            this._referenceRepository = referenceRepository;
            this._clientRepository = clientRepository;
            this._logger = logger;

            _transformations = new List<Transformation>
            {
                new ClientTypeLookup(_referenceRepository),
                new CountryNameLookup(_referenceRepository),
                new CountryCode2Lookup(_referenceRepository),
                new CountryCode3Lookup(_referenceRepository),
                new AccountIDLookup(_clientRepository)
            };
        }

        public Change Transform(Change change, string sourceSystem, string destinationSystem, string sourceTableName)
        {
            Change destinationChange = new Change();

            List<Mapping> mappings = _transformationRepository.GetMappingsBySystemsAndSourceTable(sourceSystem, destinationSystem,
                sourceTableName);

            var transformations = new List<Transformation>();
            transformations.AddRange(mappings);
            transformations.AddRange(_transformations.Where(t => t.SourceSystemName == sourceSystem && t.DestinationSystemName == destinationSystem && t.SourceTable == sourceTableName));

            foreach (Field field in change.Fields)
            {
                foreach (var transformation in transformations.Where(m => m.SourceColumn == field.Name))
                {
                    try
                    {
                        destinationChange.Fields.Add(transformation.Apply(field));
                    }
                    catch (Exception e)
                    {
                        _logger.Log(e.Message);
                    }                    
                }
            }

            destinationChange.TableName = transformations.First().DestinationTable;

            return destinationChange;
        }         
    }
}
