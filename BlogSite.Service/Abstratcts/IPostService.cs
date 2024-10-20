using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using Core.Responses;
using Core.Services;

namespace BlogSite.Service.Abstratcts;

public interface IPostService : IService<Post, Guid, PostResponseDto,CreatePostRequest, UpdatePostRequest>
{
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long authorId);
    ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text);
}
