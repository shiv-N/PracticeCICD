using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interfaces
{
    public interface IEmployeeRL<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        bool Add(TEntity entity);
        bool Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
