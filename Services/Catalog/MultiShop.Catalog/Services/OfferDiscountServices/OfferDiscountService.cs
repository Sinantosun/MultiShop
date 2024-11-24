using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _OfferDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _OfferDiscountCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var mappedValues = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _OfferDiscountCollection.InsertOneAsync(mappedValues);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _OfferDiscountCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _OfferDiscountCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<ResultOfferDiscountByIdDto> GetOfferDiscountByIdAsync(string id)
        {
            var values = await _OfferDiscountCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultOfferDiscountByIdDto>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var mappedValues = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _OfferDiscountCollection.FindOneAndReplaceAsync(t => t.Id == updateOfferDiscountDto.Id, mappedValues);
        }
    }
}
