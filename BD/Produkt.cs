namespace BD;
public class Produkt
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string? Opis { get; set; }
    public decimal Cena { get; set; }
    public Kategoria Kategoria { get; set; }
    public ICollection<ProduktWSklepie>? ProduktWSklepie { get; set; }
}
