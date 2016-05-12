using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll(string username);
        TEntity Get(string username);
        void Add(TEntity entity);
    }
}
