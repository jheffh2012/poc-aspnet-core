using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.EntityFramework.Context;
using poc.AspNet.Core.Ioc.Repository;

namespace poc.AspNet.Core.Ioc.EntityFramework.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(SqlServerDBContext dbContext) : base(dbContext)
        {

        }
    }
}
