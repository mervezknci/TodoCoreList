using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoCoreList.Data.Entities;
using TodoCoreList.Data.Providers;
using TodoCoreList.Data.Providers.Interface;
using TodoCoreList.DTO.Extensions;
using TodoCoreList.DTO.Models.Todos;
using TodoCoreList.Service.Services.Interface;

namespace TodoCoreList.Service.Services
{
    public class TodoService : BaseService<ITodoProvider, Todo>, ITodoService
    {
        public TodoService(ITodoProvider todoProvider) :base(todoProvider)
        {

        }

        public IQueryable<TodoListDto> GetAll()
        {
            return DataProvider.GetAll().OrderByDescending(x => x.Id).ProjectTo<TodoListDto>();
        }

        public TodoDto AddOrSet(int? id, TodoDto model)
        {
            if(id.HasValue)
            {
                return base.Update<TodoDto>((int)id, model);
            }
            else
            {
                return base.Add<TodoDto>(model);
            }
        }
    }
}
