namespace BD
{
    public class Sklep
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public ICollection<ProduktWSklepie> ProduktWSklepie { get; set; }

    }
}