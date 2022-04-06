using ProjektSklepu.Services;

namespace ProjektSklepu.Models;

public class ProduktViewModel
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string? Opis { get; set; }
    public decimal Cena { get; set; }
    public KategoriaViewModel Kategoria { get; set; }
}
