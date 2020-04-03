using System.Linq;
using TodoCoreList.Data.Entities;
using TodoCoreList.DTO.Models.Todos;

namespace TodoCoreList.Service.Services.Interface
{
    public interface ITodoService : IBaseService<Todo>
    {
        IQueryable<TodoListDto> GetAll();
        TodoDto AddOrSet(int? id, TodoDto model);
    }
}
