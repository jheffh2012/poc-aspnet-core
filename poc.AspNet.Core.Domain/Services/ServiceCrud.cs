using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace poc.AspNet.Core.Domain.Services
{
    public class ServiceCrud<TEntity> : IServiceCrud<TEntity> where TEntity : BaseModel
    {

        protected readonly IRepository<TEntity> _repository;

        public ServiceCrud(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll(new string[] { }, null);
        }

        public virtual TEntity GetById(int Id, string[] includes = null)
        {
            return _repository.GetById(new BaseModel { Id = Id }, includes);
        }

        public virtual void Add(TEntity model)
        {
            _repository.Add(model);
        }

        public virtual void Update(TEntity model)
        {
            _repository.Update(model);
        }

        public virtual void Delete(TEntity model)
        {
            _repository.Delete(model);
        }

        public async Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(model, cancellationToken);
        }

        public async Task<TEntity> UpdateAsync(BaseModel id, TEntity model, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(id, model, cancellationToken);
        }

        public Task DeleteAsync(BaseModel id, CancellationToken cancellationToken)
        {
            return _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
