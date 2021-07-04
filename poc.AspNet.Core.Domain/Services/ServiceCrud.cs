using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.Repository;
using System.Collections.Generic;

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
    }
}
