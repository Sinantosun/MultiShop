using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var mappedValues = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(mappedValues);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultFeatueDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultFeatueDto>>(values);
        }

        public async Task<ResultFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            var values = await _featureCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureByIdDto>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var mappedValues = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(t => t.Id == updateFeatureDto.Id, mappedValues);
        }
    }
}
