
namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string text, long UserId, Guid PostId);
