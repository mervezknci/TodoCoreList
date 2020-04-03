using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoCoreList.Data.Entities
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }
    }
}