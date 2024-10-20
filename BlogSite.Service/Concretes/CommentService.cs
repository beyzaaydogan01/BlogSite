
using AutoMapper;
using BlogSite.DataAccess.Abstract;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CommentService(
    ICommentRepository _commentRepository,
    IMapper _mapper) : ICommentService
{
    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest request)
    {
        Comment comment = _mapper.Map<Comment>(request);
        _commentRepository.Add(comment);
        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = commentResponseDto,
            Message = "Comment added",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest request)
    {
        Comment comment = _mapper.Map<Comment>(request);
        _commentRepository.Update(comment);
        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = commentResponseDto,
            Message = "Comment updated",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Delete(Guid id)
    {
        Comment? comment = _commentRepository.GetById(id);
        if (comment == null)
        {
            return new ReturnModel<CommentResponseDto>()
            {
                Message = "Comment not found",
                StatusCode = 404,
                Success = false
            };
        }

        _commentRepository.Remove(comment);
        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = commentResponseDto,
            Message = "Comment deleted",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto?> GetById(Guid id)
    {
        Comment? comment = _commentRepository.GetById(id);
        if (comment == null)
        {
            return new ReturnModel<CommentResponseDto?>()
            {
                Message = "Comment not found",
                StatusCode = 404,
                Success = false
            };
        }

        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto?>()
        {
            Data = commentResponseDto,
            Message = "Comment retrieved",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        List<Comment> comments = _commentRepository.GetAll();
        List<CommentResponseDto> commentResponseDtos = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>()
        {
            Data = commentResponseDtos,
            Message = "Comments retrieved",
            StatusCode = 200,
            Success = true
        };
    }
}
