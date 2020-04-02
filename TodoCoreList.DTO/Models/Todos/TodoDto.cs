using System;
using System.Collections.Generic;
using System.Text;

namespace TodoCoreList.DTO.Models.Todos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate1 { get; set; }
        public int Durum { get; set; }
    }
}
