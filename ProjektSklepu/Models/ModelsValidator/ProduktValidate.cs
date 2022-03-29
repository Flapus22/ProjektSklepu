using BD;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepu.Models.ModelsValidetor;

internal class ProduktValidate : AbstractValidator<ProduktViewModel>
{
    public ProduktValidate(Context db)
    {
        RuleFor(x => x.Nazwa).Length(5, 50).NotNull();
        RuleFor(x => x.Opis).MaximumLength(200);
        RuleFor(x => x.Cena).GreaterThan(0).NotNull();
    }
}
