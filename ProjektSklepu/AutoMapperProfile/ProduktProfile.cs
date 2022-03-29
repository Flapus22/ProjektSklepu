using AutoMapper;
using BD;
using ProjektSklepu.Models;

namespace ProjektSklepu.AutoMapperProfile;

public class ProduktProfile : Profile
{
    public ProduktProfile()
    {
        CreateMap<Produkt, ProduktViewModel>().ReverseMap();
        CreateMap<Kategoria, KategoriaViewModel>().ReverseMap();

        //CreateMap<ProduktViewModel, Produkt>()
        //    .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
        //    .ForMember(x => x.Nazwa, y => y.MapFrom(z => z.Nazwa))
        //    .ForMember(x => x.Opis, y => y.MapFrom(z => z.Opis))
        //    .ForMember(x => x.Cena, y => y.MapFrom(z => z.Cena));
    }
}
