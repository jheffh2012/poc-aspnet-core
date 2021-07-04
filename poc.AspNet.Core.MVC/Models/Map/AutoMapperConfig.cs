using AutoMapper;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.MVC.Models.Map
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Equipe, EquipeViewModel>().ReverseMap();
            CreateMap<Calendario, CalendarioViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<EventoConfirmacao, EventoConfirmacaoViewModel>().ReverseMap();

            CreateMap<PrevisaoTempoCidade, PrevisaoTempoCidadeViewModel>()
                .ForMember(e => e.Cidade, opt => opt.MapFrom(u => u.city_name))
                .ForMember(e => e.Temperatura, opt => opt.MapFrom(u => u.temp));
        }
    }
}
