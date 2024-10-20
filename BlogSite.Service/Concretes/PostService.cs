
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create)
    {
        try
        {
            _businessRules.TitleAndContentValidation(create);
            _businessRules.ContentLengthValidation(create.Content);

            Post createdPost = _mapper.Map<Post>(create);
            createdPost.Id = Guid.NewGuid();

            _postRepository.Add(createdPost);

            PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "Post Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);


        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message= string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long authorId)
    {
        List<Post> posts = _postRepository.GetAllByAuthorId(authorId);

        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Yazar Id numarasına göre Postlar listelendi : Yazar Id: {authorId}",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        List<Post> posts = _postRepository.GetAllByCategoryId(id);

        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Kategori Id numarasına göre Postlar listelendi : Kategori Id: {id}",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        List<Post> posts = _postRepository.GetAllByTitleContains(text);

        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto?> GetById(Guid id)
    {
        try
        {
            _businessRules.PostIsPresent(id);

            Post post = _postRepository.GetById(id);

            PostResponseDto response = _mapper.Map<PostResponseDto>(post);
            return new ReturnModel<PostResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<PostResponseDto> Delete(Guid id)
    {
        try
        {
            _businessRules.PostIsPresent(id);

            Post? post = _postRepository.GetById(id);
            Post deletedPost = _postRepository.Remove(post);

            PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "Post Silindi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }

    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost)
    {
        try
        {
            _businessRules.PostIsPresent(updatePost.Id);
            _businessRules.ContentLengthValidation(updatePost.Content);

            Post post = _postRepository.GetById(updatePost.Id);

            Post update = new Post
            {
                CategoryId = post.CategoryId,
                Content = updatePost.Content,
                Title = updatePost.Title,
                AuthorId = post.AuthorId,
                CreatedDate = post.CreatedDate,
            };

            Post updatedPost = _postRepository.Update(update);

            PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);
            return new ReturnModel<PostResponseDto>
            {
                Data = dto,
                Message = "Post güncellendi",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }

    }
}
