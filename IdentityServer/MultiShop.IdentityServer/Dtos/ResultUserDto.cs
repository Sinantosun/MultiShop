namespace MultiShop.IdentityServer.Dtos
{
    public class ResultUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string FullName { get => Name + " " + Surname; }
    }
}
