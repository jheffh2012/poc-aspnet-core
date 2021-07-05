using poc.AspNet.Core.Ioc.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace poc.AspNet.Core.Ioc.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> GetAll(string[] includes, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(BaseModel Id, string[] includes);
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(BaseModel id, TEntity model, CancellationToken cancellationToken);
        Task DeleteAsync(BaseModel id, CancellationToken cancellationToken);
    }
}
