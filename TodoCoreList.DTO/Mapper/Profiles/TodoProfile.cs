using AutoMapper;
using TodoCoreList.Data.Entities;
using TodoCoreList.DTO.Models.Todos;

namespace TodoCoreList.DTO.Mapper.Profiles
{
    internal class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            //.ForMember(x=> x.DueDate1, y=> y.MapFrom(f=> f.DueDate));
            CreateMap<Todo, TodoListDto>();
            CreateMap<Todo, TodoCheckStatusDto>().ReverseMap();
        }
    }
}
