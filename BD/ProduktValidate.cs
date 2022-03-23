using BD;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    internal class ProduktValidate : AbstractValidator<Produkt>
    {
        public ProduktValidate(Context db)
        {
            RuleFor(x => x.Nazwa).Length(5, 50);
            RuleFor(x => x.Opis).MaximumLength(200);
            RuleFor(x => x.Cena).LessThan(0);
        }
    }
}
