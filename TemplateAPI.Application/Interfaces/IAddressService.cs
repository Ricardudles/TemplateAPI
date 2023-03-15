using Template.Application.DTOs;
using Template.Domain.Entities;
using Template.Application.BaseResponse;

namespace Template.Application.Interfaces
{
    public interface IAddressService
    {
        Task<BaseOutput<List<Address>>> GetAll();
        Task<BaseOutput<int>> RegisterAddress(AddressDto addressDto);
        Task<bool> VerifyAddress(int Id);
        Task<BaseOutput<bool>> DeleteAddress(int Id);
    }
}