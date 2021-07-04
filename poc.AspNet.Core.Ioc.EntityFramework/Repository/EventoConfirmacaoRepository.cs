using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.EntityFramework.Context;
using poc.AspNet.Core.Ioc.Repository;

namespace poc.AspNet.Core.Ioc.EntityFramework.Repository
{
    public class EventoConfirmacaoRepository : Repository<EventoConfirmacao>, IEventoConfirmacaoRepository
    {

        public EventoConfirmacaoRepository(SqlServerDBContext dbContext) : base(dbContext)
        {

        }
    }
}
