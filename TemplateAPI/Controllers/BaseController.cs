using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Template.Application.BaseResponse;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult InternalErrorResponse(Exception ex)
        {
            var response = new BaseOutput<string>();
            response.AddError(ex.Message);
            return StatusCode(500, response);
        }

        protected IActionResult BadRequestResponse(string msg)
        {
            var response = new BaseOutput<string>();
            response.AddError(msg);
            return StatusCode(400, response);
        }

        protected IActionResult ValidatorErrorResponse(List<ValidationFailure> errors)
        {
            var response = new BaseOutput<string>();
            errors.ForEach(error =>
            {
                response.AddError(error.ErrorMessage);
            });
            return StatusCode(400, response);
        }
    }
}