using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(TKey key);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey key);
    }
}
