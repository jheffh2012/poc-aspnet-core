using poc.AspNet.Core.Ioc.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IServiceCrud<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id, string[] includes = null);
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(BaseModel id, TEntity model, CancellationToken cancellationToken);
        Task DeleteAsync(BaseModel id, CancellationToken cancellationToken);
    }
}
