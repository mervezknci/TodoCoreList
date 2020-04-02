using System;
using System.Collections.Generic;
using System.Text;
using TodoCoreList.Data.Enums;

namespace TodoCoreList.Data.Entities
{
    public class Todo : BaseEntity<int>
    {
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
