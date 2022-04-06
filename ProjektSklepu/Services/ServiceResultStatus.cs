using System.ComponentModel;

namespace ProjektSklepu.Services;

public enum ServiceResultStatus
{
    [Description("Błąd")]
    Error = 0,
    [Description("Sukces")]
    Succes = 1,
    [Description("Ostrzeżenie")]
    Warrnig,
    [Description("Informacja")]
    Info,
}



