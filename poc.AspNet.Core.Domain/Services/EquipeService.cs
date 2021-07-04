using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;

namespace poc.AspNet.Core.Domain.Services
{
    public class EquipeService : ServiceCrud<Equipe>, IEquipeService
    {
        public EquipeService(IEquipeRepository repository) : base(repository)
        {
        }
    }
}
