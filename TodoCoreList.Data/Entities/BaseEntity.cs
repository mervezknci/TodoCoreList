using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoCoreList.Data.Entities
{
    //public class BaseEntity<T> where T : struct (?Null de�er at�lam�yor diye d��n�yoruz..)

    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }
    }
}