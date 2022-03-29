namespace BD;

public class ProduktWSklepie
{
    public int Id { get; set; }
    public int ProduktId { get; set; }
    public Produkt Produkt { get; set; }
    public int SklepID { get; set; }
    public Sklep Sklep { get; set; }
    public decimal CenaWSklepie { get; set; }
}
