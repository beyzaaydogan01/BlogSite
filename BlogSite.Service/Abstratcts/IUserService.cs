
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using Core.Responses;
using Core.Services;

namespace BlogSite.Service.Abstratcts;

public interface IUserService : IService<User, long, UserResponseDto, CreateUserRequest, UpdateUserRequest>
{
    ReturnModel<UserResponseDto> GetByUserName(string userName);
}
