using poc.AspNet.Core.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IEventoService : IServiceCrud<Evento>
    {
        decimal BuscarPercentualConfirmacao(Evento evento);
        IEnumerable<Evento> BuscarEventosDoUsuario(string email);
    }
}
