using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceCrud<Usuario>
    {
        Usuario Registrar(Usuario model);
        Usuario LoginValido(string email, string senha);

        Usuario BuscarDadosDoUsuario(string email);
    }
}
