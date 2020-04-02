using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TodoCoreList.Data.Providers.Interface
{
    public interface IBaseProvider<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        void Delete(T entity);
        //IEnumarable vs IQueryable???
        IQueryable<T> GetAll();
        T GetById(int Id);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
