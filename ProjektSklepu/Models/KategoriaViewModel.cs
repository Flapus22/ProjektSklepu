using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektSklepu.Services;

namespace ProjektSklepu.Models;
public class KategoriaViewModel : SelectListItem
{
    public int Id { get; set; }
    public string NazwaKategorii { get; set; }
}
