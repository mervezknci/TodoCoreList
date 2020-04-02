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
        where TBaseProvider : BaseProvider<TEntity>
    {
        private readonly TBaseProvider _baseProvider;
        public BaseService(TBaseProvider baseProvider)
        {
            _baseProvider = baseProvider;
        }

        public TModel Add<TModel>(TModel model)
        {
            var entity = model.Map<TEntity>();
            _baseProvider.Add(entity);
            _baseProvider.SaveChanges();
            return model.Map<TModel>();
        }

        public void Delete(int Id)
        {
            _baseProvider.Delete(Id);
            _baseProvider.SaveChanges();
        }

        public IQueryable<TModel> Find<TModel>(Expression<Func<TEntity, bool>> expression)
        {
            return _baseProvider.Find(expression).ProjectTo<TModel>();
        }

        public IQueryable<TModel> GetAll<TModel>()
        {

            return _baseProvider.GetAll().ProjectTo<TModel>();
        }

        public TModel GetById<TModel>(int Id)
        {
            return _baseProvider.GetById(Id).Map<TModel>();
        }

        public TModel Update<TModel>(int Id, TModel model)
        {
            var entity = _baseProvider.GetById(Id);
            model.Map(entity);
            _baseProvider.SaveChanges();
            return model.Map<TModel>();
        }
    }
}
