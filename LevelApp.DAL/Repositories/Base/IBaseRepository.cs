﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LevelApp.DAL.Models.Base;

namespace LevelApp.DAL.Repositories.Base
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetDetail(Func<TEntity, bool> predicate);
        Task<TEntity> GetDetailAsync(Expression<Func<TEntity, bool>> predicate);
        bool CheckIfExists(Func<TEntity, bool> predicate);
        Task<bool> CheckIfExistsAsync(Expression<Func<TEntity, bool>> predicate);
        TKey Insert(TEntity entity);
        void InsertBatch(IEnumerable<TEntity> entities);
        TKey Update(TEntity entity);
        void UpdateBatch(IEnumerable<TEntity> entities);
        TKey Delete(TEntity entity);
        void DeleteBatch(IEnumerable<TEntity> entities);
        void Save();
        void SaveAsync();
    }
}