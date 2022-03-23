namespace ProjektSklepu.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }

        public ShopViewModel(int id, string name, string city, string country, string street, string postCode)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
            Street = street;
            PostCode = postCode;
        }
    }
}
