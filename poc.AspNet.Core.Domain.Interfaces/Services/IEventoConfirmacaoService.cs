using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IEventoConfirmacaoService : IServiceCrud<EventoConfirmacao>
    {

        void UsuarioConfirmaPresenca(string email, int Id);
    }

}
