
using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstract;

public interface ICommentRepository : IRepository<Comment, Guid>
{
}
