
namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record UpdateCommentRequest(Guid Id, string Text);
