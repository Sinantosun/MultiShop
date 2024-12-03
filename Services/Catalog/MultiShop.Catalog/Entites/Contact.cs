namespace MultiShop.Catalog.Entites
{
    public class Contact : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string SendDate { get; set; }
    }
}
