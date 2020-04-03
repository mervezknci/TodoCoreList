using System;
using System.Collections.Generic;
using System.Text;
using TodoCoreList.Data.Enums;

namespace TodoCoreList.DTO.Models.Todos
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TodoStatus Status { get; set; }
    }
}
