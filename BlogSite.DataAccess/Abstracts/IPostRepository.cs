using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;
public interface IPostRepository : IRepository<Post,Guid>
{
    List<Post> GetAllByCategoryId(int categoryId);
    List<Post> GetAllByAuthorId(long authorId);
    List<Post> GetAllByTitleContains(string text);
}
