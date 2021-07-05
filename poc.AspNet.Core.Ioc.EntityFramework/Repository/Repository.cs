using Microsoft.EntityFrameworkCore;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.Ioc.EntityFramework.Context;
using poc.AspNet.Core.Ioc.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace poc.AspNet.Core.Ioc.EntityFramework.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        public readonly SqlServerDBContext _dbContext;

        public Repository(SqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll(string[] includes, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public TEntity GetById(BaseModel Id, string[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();
            query.Where(e => e.Id == Id.Id);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.FirstOrDefault();
        }


        public void Add(TEntity model)
        {
            _dbContext.Set<TEntity>().Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void Delete(TEntity model)
        {
            _dbContext.Entry(model).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public async Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken)
        {
            var retorno = await _dbContext.Set<TEntity>().AddAsync(model);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return retorno.Entity;
        }

        public async Task DeleteAsync(BaseModel id, CancellationToken cancellationToken)
        {
            var registro = await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id.Id);
            if (registro == null)
            {
                throw new System.Exception("Registro não encontrado!");
            }
            _dbContext.Set<TEntity>().Remove(registro);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> UpdateAsync(BaseModel id, TEntity model, CancellationToken cancellationToken)
        {
            model.Id = id.Id;
            var registro = _dbContext.Set<TEntity>().Update(model);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return registro.Entity;
        }
    }
}
