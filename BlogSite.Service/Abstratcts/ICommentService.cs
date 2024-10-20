
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using Core.Responses;
using Core.Services;

namespace BlogSite.Service.Abstratcts;

public interface ICommentService : IService<Comment, Guid, CommentResponseDto, CreateCommentRequest, UpdateCommentRequest>
{
}
