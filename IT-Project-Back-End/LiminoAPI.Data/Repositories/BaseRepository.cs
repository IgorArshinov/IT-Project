using System;
using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;


        #region Constructor

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        #endregion Constructor

        public virtual long Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            var id = entity.Id;
            
            return id;
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return  Context.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllWhere(Func<T, bool> property)
        {
            return Context.Set<T>().Where(property).AsEnumerable();
        }

        public virtual T GetById(long id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }


        public virtual T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

            return entity;
        }
    }
}
