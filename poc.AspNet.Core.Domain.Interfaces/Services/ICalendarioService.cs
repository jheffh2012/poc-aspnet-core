using poc.AspNet.Core.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface ICalendarioService : IServiceCrud<Calendario>
    {
        IEnumerable<Calendario> BuscarCalendariosDoUsuario(string email);
    }
}
