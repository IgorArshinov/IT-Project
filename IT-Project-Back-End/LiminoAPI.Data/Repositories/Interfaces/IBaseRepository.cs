using System;
using System.Collections.Generic;
using LiminoAPI.Data.Models;

namespace LiminoAPI.Data.Repositories.Interfaces
{
    public  interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWhere(Func<T, bool> property);
        T GetById(long id);
        long Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
