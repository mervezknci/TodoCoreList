using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TodoCoreList.Service.Services.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TModel Add<TModel>(TModel model);
        TModel Update<TModel>(int Id, TModel model);
        void Delete(int Id);
        IQueryable<TModel> GetAll<TModel>();
        TModel GetById<TModel>(int Id);
        IQueryable<TModel> Find<TModel>(Expression<Func<TEntity, bool>> expression);

    }
}
