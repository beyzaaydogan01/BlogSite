using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>,IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Post> GetAllByAuthorId(long authorId)
    {
        List<Post> posts = Context.Posts.Where(x => x.AuthorId == authorId).ToList();
        return posts;
    }

    public List<Post> GetAllByCategoryId(int categoryId)
    {
        List<Post> posts = Context.Posts.Where(x=>x.CategoryId == categoryId).ToList();
        return posts;
    }

    public List<Post> GetAllByTitleContains(string text)
    {
        List<Post> posts = Context.Posts
            .Where(x=>x.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        return posts;
    }
}
