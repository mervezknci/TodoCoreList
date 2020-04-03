using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HippoSoft.HippoErp.Api.Filter
{
    /// <summary>
    /// Custom validation state
    /// Gelen istekte modelle ilgili bir hata varsa ResponseModel içerisinde bulunan ErrorModel hatası oluşturularak yanıt verir.
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
#pragma warning disable CS1591
        public override void OnActionExecuting(ActionExecutingContext context)
#pragma warning restore CS1591
        {
            //Gelen model doğrulandı ise işlem yapmaya gerek yok.
            //if (context.ModelState.IsValid) return;
            //var field = context.ModelState.Where(x=> x.Value.ValidationState == ModelValidationState.Invalid).Select(x => new FieldModel
            //{
            //    Field = x.Key,
            //    Message = x.Value.Errors.Select(y => y.ErrorMessage).ToArray()
            //});
            //var result = new ResponseModel()
            //{
            //    Error = new ErrorModel()
            //    {
            //        Fields = field
            //    }
            //};
            //context.Result = new BadRequestObjectResult(result);
        }
    }
}
