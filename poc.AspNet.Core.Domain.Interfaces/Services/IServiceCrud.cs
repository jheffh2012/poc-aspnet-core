using poc.AspNet.Core.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IServiceCrud<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id, string[] includes = null);
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
    }
}
