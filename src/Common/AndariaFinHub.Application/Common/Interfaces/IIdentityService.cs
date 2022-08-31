using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password);

        Task<bool> UserIsInRole(string userId, string role);

        Task<Result> DeleteUserAsync(string userId);
    }
}
