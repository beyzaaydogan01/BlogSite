
using AutoMapper;
using Azure.Core;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class UserService(IUserRepository _userRepository, 
    IMapper _mapper, 
    UserBusinessRules _userBusinessRules) : IUserService 
{
    public ReturnModel<UserResponseDto> Add(CreateUserRequest create)
    {
        try
        {
            _userBusinessRules.IsExistUserName(create.Username);

            User createdUser = _mapper.Map<User>(create);

            _userRepository.Add(createdUser);

            UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "Kullanıcı Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
         
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        List<User> users = _userRepository.GetAll();

        List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);

        return new ReturnModel<List<UserResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> GetByUserName(string userName)
    {
            User? user = _userRepository.GetByUserName(userName);
            UserResponseDto response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
    }

    public ReturnModel<UserResponseDto?> GetById(long id)
    {
        try
        {
            _userBusinessRules.IsUserIdExist(id);

            User user = _userRepository.GetById(id);

            UserResponseDto response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<UserResponseDto> Delete(long id)
    {
        try
        {
            _userBusinessRules.IsUserIdExist(id);

            User user = _userRepository.GetById(id);
            User deletedUser = _userRepository.Remove(user);

            UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "Kullanıcı Silindi",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser)
    {
        try
        {
            _userBusinessRules.IsExistUserName(updateUser.Username);
            User user = _mapper.Map<User>(updateUser);
            _userRepository.Update(user);

            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>()
            {
                Data = userResponseDto,
                Message = "User updated",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
        
    }
}
