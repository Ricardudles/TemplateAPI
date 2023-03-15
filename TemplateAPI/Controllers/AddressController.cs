using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Application.DTOs;
using Template.Application.Interfaces;
using Template.Domain.Entities;
using System.Net;
using Template.Application.BaseResponse;

namespace Template.Api.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _addressService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterAddress([FromBody] AddressDto addressDto, [FromServices] IValidator<AddressDto> validator)
        {
            try
            {
                ValidationResult validationResult = validator.Validate(addressDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                var response = await _addressService.RegisterAddress(addressDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete, Authorize]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAddress([FromQuery] int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequestResponse("Incorrect Entry");
                }

                var response = await _addressService.DeleteAddress(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
