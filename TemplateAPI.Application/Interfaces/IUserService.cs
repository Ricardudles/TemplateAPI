using Template.Application.DTOs;
using Template.Domain.Entities;
using Template.Application.BaseResponse;

namespace Template.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int Id);
        Task<User> GetUser(UserDto userDto);
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<bool> VerifyUser(UserDto userDto);

    }
}