using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace com.capital.bet.data.Repository.Interfaces
{
    /// <summary>
    /// repository pattern interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add Entity To Repository
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// Add A Range of entries to the repository
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Update Entry
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// Update range of entries
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Remove entry
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        /// <summary>
        /// Remove Range of entries
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Count Records
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// find record using predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Get a single or empty record with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Get entry by record id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(object id);
        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
    }
}
