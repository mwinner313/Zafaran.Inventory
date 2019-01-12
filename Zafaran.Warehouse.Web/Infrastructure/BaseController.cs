using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Zafaran.WareHouse.Web.Infrastructure
{
    public class BaseController:Controller
    {
        protected BadRequestObjectResult BadRequestWithModelStateErrors()
        {
            return BadRequest(ModelState.Values.SelectMany(x=>x.Errors.Select(e=>e.ErrorMessage)).ToList());
        }
    }
}
