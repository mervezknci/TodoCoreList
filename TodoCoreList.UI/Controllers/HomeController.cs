using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using TodoCoreList.DTO.Models.Todos;
using TodoCoreList.Service.Services.Interface;
using TodoList.UI.Models;

namespace TodoCoreList.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoService _todoService;

        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public ActionResult Index()
        {
            var model = _todoService.GetAll();
            return View(model);
        }

        //[ValidateModelStateAttribute]
        [HttpPost]
        public JsonResult AddOrUpdate(int? id, TodoDto model)
        {
            if (ModelState.IsValid)
            {
                _todoService.AddOrSet(id, model);
            }

            return Json(new Result { Success = true });
        }

        [HttpPost]
        public JsonResult CheckStatus(int id, TodoCheckStatusDto model)
        {
            var result = new Result();
            try
            {
                var entity = _todoService.Update<TodoCheckStatusDto>(id, model);
                result.Success = true;
            }
            catch (Exception x)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = "Err-Excp",
                    Message = x.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteTodo(int id)
        {
            var result = new Result();
            try
            {
                _todoService.Delete(id);
                result.Success = true;
            }
            catch (Exception x)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = "Err-Excp",
                    Message = x.Message
                };
            }
            return Json(result);
        }

        //[HttpGet]
        //public JsonResult OutDatedTodo()
        //{
        //    var result = new Result<TodoDto>();

        //    var data = _todoService.TodoRepository.GetAll()
        //        .Where(x => EntityFunctions.TruncateTime(x.DueDate) == EntityFunctions.TruncateTime(DateTime.Now)).ProjectTo<TodoDto>();

        //    return Json(new Result<IEnumerable<TodoDto>>
        //    {
        //        Data = data
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}
