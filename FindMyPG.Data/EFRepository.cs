using FindMyPG.Core.Data;
using FindMyPG.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private IDbContext _context;
        private DbSet<TEntity> _entities;
        public EFRepository(IDbContext context)
        {
            _context = context;
        }
        public virtual DbSet<TEntity> Entities
        {
            get
            {
                if(_entities==null)
                {
                    _entities=_context.Set<TEntity>();
                }
                return _entities;
            }
        }
        public IQueryable<TEntity> Table => Entities;

        public void Delete(TEntity entity)
        {
            if(entity==null)
            throw new NullReferenceException();

            Entities.Remove(entity);
            _context.SaveChange();
        }

        public TEntity GetById(object id)
        {

            //return Entities.Where(x=>x.Id ==Convert.ToInt32(id)).First();// First() Give IEnuemrable<TEntity> to a Single Entity 
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException();
            Entities.Add(entity);
            _context.SaveChange();
        }
        
        public void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new NullReferenceException();
            Entities.AddRange(entities);
            _context.SaveChange();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw  new NullReferenceException();
            Entities.Update(entity);
            _context.SaveChange();
        }
    }
}
