namespace MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos

{
    public class UpdateContactDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
