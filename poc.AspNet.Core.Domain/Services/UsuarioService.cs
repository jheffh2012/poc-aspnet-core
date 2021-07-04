using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System.Linq;

namespace poc.AspNet.Core.Domain.Services
{
    public class UsuarioService : ServiceCrud<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }

        public Usuario BuscarDadosDoUsuario(string email)
        {
            return _repository.GetAll(new string[] { "EventosOrganizados", "Confirmacoes", "Equipe" }, e => e.Email == email).FirstOrDefault();
        }

        public override Usuario GetById(int Id, string[] includes = null)
        {
            return _repository.GetById(new BaseModel { Id = Id }, includes);
        }

        public Usuario LoginValido(string email, string senha)
        {
            var usuarios = _repository.GetAll(new string[] { }, e => e.Email == email && e.Senha == senha);

            return usuarios.FirstOrDefault();
        }

        public Usuario Registrar(Usuario model)
        {
            var usuarios = _repository.GetAll(new string[] { }, e => e.Email == model.Email);

            if (usuarios.Count() > 0)
            {
                return null;
            }

            _repository.Add(model);
            return model;
        }
    }
}
