﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain;
using VietBND.Domain.Repositories;

namespace shopping_cart_infrastructures.Repositories
{
    public class EfRepository<TEntity, TPrimaryKey> : BaseRepository<TEntity, TPrimaryKey>, IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _table;
        public EfRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Instance.Set<TEntity>();
        }
        public override bool Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            if(predicate == null)
                return GetAll().Any();
            return GetAll().Any(predicate);
        }

        public override void Delete(TEntity entity)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            _table.Update(entity);
        }

        public override void Delete(params TPrimaryKey[] ids)
        {
            var entities = GetAll().Where(s => ids.Contains(s.Id)).ToArray();
            foreach(var entity in entities)
            {
                Delete(entity);
            }
        }

        public override TEntity Find(TPrimaryKey id)
        {
            return GetAll().SingleOrDefault(CreateEqualityExpressionForId(id));
        }

        public override TEntity First(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetAll().First(predicate);
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public override IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _table.Where(CreateEqualityExpressionForIsDeleted());
            if (predicate == null)
                return query;
            return query.Where(predicate);
        }

        public override TEntity Insert(TEntity entity)
        {
            var result = _table.Add(entity);
            _dbContext.Instance.Entry(entity).State = EntityState.Added;
            return result.Entity;
        }

        public override TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return GetAll().SingleOrDefault();
            return GetAll().SingleOrDefault(predicate);
        }

        public override void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
