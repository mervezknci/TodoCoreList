using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoCoreList.Data.Entities;
using TodoCoreList.Data.Providers.Interface;

namespace TodoCoreList.Data.Providers
{
    public class TodoProvider : BaseProvider<Todo>, ITodoProvider
    {
        public TodoProvider(DbContext context) : base(context)
        {
        }
    }
}
