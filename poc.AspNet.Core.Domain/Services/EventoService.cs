using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System.Collections.Generic;
using System.Linq;

namespace poc.AspNet.Core.Domain.Services
{
    public class EventoService : ServiceCrud<Evento>, IEventoService
    {
        protected readonly ICalendarioService _serviceCalendario;
        protected readonly IEquipeService _serviceEquipe;

        public EventoService(
            IEventoRepository repository,
            ICalendarioService serviceCalendario,
            IEquipeService serviceEquipe
        ) : base(repository)
        {
            _serviceCalendario = serviceCalendario;
            _serviceEquipe = serviceEquipe;
        }

        public IEnumerable<Evento> BuscarEventosDoUsuario(string email)
        {
            ICollection<Calendario> calendarios = _serviceCalendario.BuscarCalendariosDoUsuario(email) as ICollection<Calendario>;

            return _repository.GetAll(new string[] { }, e => calendarios.Where(i => i.Id == e.IdCalendario).Any());
        }

        public decimal BuscarPercentualConfirmacao(Evento evento)
        {
            var eventoAtual = _repository.GetById(evento, new string[] { "Confirmacoes" });

            var calendario = _serviceCalendario.GetById(evento.IdCalendario);

            var equipe = _serviceEquipe.GetById(calendario.IdEquipe, new string[] { "Usuarios" });

            if (eventoAtual.Confirmacoes.Count() == 0 || equipe.Usuarios.Count() == 0)
            {
                return 0;
            }

            decimal confirmacoes = eventoAtual.Confirmacoes.Count();
            decimal usuarios = equipe.Usuarios.Count();

            decimal percentual = confirmacoes / usuarios;

            return (percentual * 100);
        }
    }
}
