
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public void TitleAndContentValidation(CreatePostRequest create)
    {
        if (string.IsNullOrWhiteSpace(create.Content) && string.IsNullOrWhiteSpace(create.Title))
        {
            throw new ArgumentNullException("Content ve title alanı boş geçilemez.");
        }
    }
    public void ContentLengthValidation(string content)
    {
        if (content.Length < 10 || content.Length > 5000)
        {
            throw new BusinessException("İçerik en az 10, en fazla 5000 karakter olmalıdır.");
        }
    }
    public void PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post == null)
        {
            throw new NotFoundException($"İlgili id numarasına göre post bulunamadı. {id}");
        }
    }
}
