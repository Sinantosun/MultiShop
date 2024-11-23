using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<Specialoffer> _spacialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _spacialOfferCollection = database.GetCollection<Specialoffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var mappedValues = _mapper.Map<Specialoffer>(createSpecialOfferDto);
            await _spacialOfferCollection.InsertOneAsync(mappedValues);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _spacialOfferCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _spacialOfferCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<ResultSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id)
        {
            var value = await _spacialOfferCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultSpecialOfferByIdDto>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var mappedValues = _mapper.Map<Specialoffer>(updateSpecialOfferDto);
            await _spacialOfferCollection.FindOneAndReplaceAsync(t => t.Id == updateSpecialOfferDto.Id, mappedValues);
        }
    }
}
