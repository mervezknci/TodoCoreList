using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TodoCoreList.Data.Providers;
using TodoCoreList.Data.Providers.Interface;
using TodoCoreList.DTO.Extensions;
using TodoCoreList.Service.Services.Interface;

namespace TodoCoreList.Service.Services
{
    public abstract class BaseService<TBaseProvider,TEntity> : IBaseService<TEntity> where TEntity : class 
        where TBaseProvider : IBaseProvider<TEntity>
    {
        protected readonly TBaseProvider DataProvider;
        public BaseService(TBaseProvider baseProvider)
        {
            DataProvider = baseProvider;
        }

        public TModel Add<TModel>(TModel model)
        {
            var entity = model.Map<TEntity>();
            DataProvider.Add(entity);
            DataProvider.SaveChanges();
            return model.Map<TModel>();
        }

        public void Delete(int Id)
        {
            DataProvider.Delete(Id);
            DataProvider.SaveChanges();
        }

        public IQueryable<TModel> Find<TModel>(Expression<Func<TEntity, bool>> expression)
        {
            return DataProvider.Find(expression).ProjectTo<TModel>();
        }

        public IQueryable<TModel> GetAll<TModel>()
        {

            return DataProvider.GetAll().ProjectTo<TModel>();
        }

        public TModel GetById<TModel>(int Id)
        {
            return DataProvider.GetById(Id).Map<TModel>();
        }

        public TModel Update<TModel>(int Id, TModel model)
        {
            var entity = DataProvider.GetById(Id);
            model.Map(entity);
            DataProvider.SaveChanges();
            return model.Map<TModel>();
        }
    }
}
