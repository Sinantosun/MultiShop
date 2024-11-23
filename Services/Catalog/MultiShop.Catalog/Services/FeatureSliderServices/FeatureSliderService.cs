using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;
        public FeatureSliderService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task ChangeFeatureSliderStatusToFalse(string id)
        {
            var value = await _featureSliderCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            value.Status = false;
            await _featureSliderCollection.FindOneAndReplaceAsync(t => t.Id == id, value);
        }

        public async Task ChangeFeatureSliderStatusToTrue(string id)
        {
            var value = await _featureSliderCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            value.Status = true;
            await _featureSliderCollection.FindOneAndReplaceAsync(t => t.Id == id, value);
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<ResultFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            var values = await _featureSliderCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureSliderByIdDto>(values);
        }

        public async Task<List<ResultFeatureSliderDto>> GetTrueFeatureSliderListAsync()
        {
            var values = await _featureSliderCollection.Find(t => t.Status == true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(t => t.Id == updateFeatureSliderDto.Id, values);
        }
    }
}
