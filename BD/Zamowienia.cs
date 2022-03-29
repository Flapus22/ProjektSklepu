namespace BD;
public class Zamowienia
{
    public int Id { get; set; }
    public Sklep SklepID { get; set; }
    public DateTime DataUtworzenia { get; set; }
    public Status Status { get; set; }
    public ICollection<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
}
