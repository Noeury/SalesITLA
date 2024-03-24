using Sales.Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Dao
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {

        private List<TEntity> entities;

        public DaoBase()
        {
            this.entities = new List<TEntity>();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(Func<TEntity, bool> filter)
        {
            return this.entities.First(filter);
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
