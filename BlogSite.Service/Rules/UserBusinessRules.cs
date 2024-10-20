
using BlogSite.DataAccess.Abstracts;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public class UserBusinessRules(IUserRepository _userRepository)
{
    public void IsUserIdExist(long id)
    {
        var user = _userRepository.GetById(id);
        if(user == null)
        {
            throw new NotFoundException($"İlgili id numarasına göre kullanıcı bulunamadı. {id}");
        }
    }

    public void IsExistUserName(string userName) 
    {
        var user = _userRepository.GetByUserName(userName);
        if(userName != null)
        {
            throw new BusinessException("$Bu kullanıcı adına sahip biri zaten mecvut!");
        }
    }
}
