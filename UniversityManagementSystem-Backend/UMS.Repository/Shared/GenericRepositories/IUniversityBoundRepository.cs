﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMS.Data;

namespace UMS.Repository.Shared.GenericRepositories
{
    public interface IUniversityBoundRepository<TEntity> where TEntity : UniversityBoundEntity, new()
    {
        IQueryable<TEntity> GetAll(long? companyId = null);
        IQueryable<TEntity> Get(long id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity AddWithoutSettingCompanyId(TEntity entity);
        IQueryable<TEntity> GetAsTracking(long id);
        void Remove(long id);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> AddRangeWithoutSettingCompanyId(IEnumerable<TEntity> entities);

        /// <summary>
        /// DO NOT USE THIS UNLESS YOU ARE SURE THAT YOU NEED THIS
        /// </summary>
        IQueryable<TEntity> WhereInAllCompanies(Expression<Func<TEntity, bool>> predicate);
        void RemoveRange(List<TEntity> entities);
        void HardRemove(long id);
        void HardRemoveRange(IEnumerable<long> ids);
    }
}
