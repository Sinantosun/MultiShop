using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<bool> CreateContactAsync(CreateContactDto createContactDto);
        Task<bool> UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<bool> DeleteContactAsync(string id);
        Task<ResultContactByIdDto> GetContactByIdAsync(string id);
    }
}
