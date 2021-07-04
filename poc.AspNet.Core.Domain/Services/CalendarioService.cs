using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System.Collections.Generic;

namespace poc.AspNet.Core.Domain.Services
{
    public class CalendarioService : ServiceCrud<Calendario>, ICalendarioService
    {
        protected readonly IUsuarioService _serviceUsuario;
        public CalendarioService(ICalendarioRepository repository, IUsuarioService serviceUsuario) : base(repository)
        {
            _serviceUsuario = serviceUsuario;
        }

        public IEnumerable<Calendario> BuscarCalendariosDoUsuario(string email)
        {
            var usuario = _serviceUsuario.BuscarDadosDoUsuario(email);

            return _repository.GetAll(new string[] { }, e => e.IdEquipe == usuario.IdEquipe);
        }
    }
}
