using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateContactAsync(CreateContactDto createContactDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts", createContactDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteContactAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Contacts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _httpClient.GetFromJsonAsync <List<ResultContactDto>>("Contacts");
            return values;
        }

        public async Task<ResultContactByIdDto> GetContactByIdAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<ResultContactByIdDto>("Contacts");
            return value;
        }

        public async Task<bool> UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contacts", updateContactDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
