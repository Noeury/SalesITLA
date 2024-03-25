using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;


namespace Sales.Infraestructure.Dao
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {
        public readonly SalesContext context;
        private DbSet<TEntity> entities;

        public DaoBase(SalesContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }



        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public virtual TEntity GetById(Func<TEntity, bool> filter)
        {
            return this.entities.First(filter);
        }

        public TEntity GetById(int Id)
        {
            return this.entities.Find(Id);
        }

        public List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }

        public virtual DataResult Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Update(entity);
            result.Success = true;

            return result;
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }


    }
}
