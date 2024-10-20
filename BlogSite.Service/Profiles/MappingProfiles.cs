using AutoMapper;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Profiles;

public class MappingProfiles: Profile
{

    public MappingProfiles()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();
        CreateMap<Post, PostResponseDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x=> x.UserName,opt=>opt.MapFrom(X=>X.Author.Username));

        CreateMap<User, UserResponseDto>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();

        CreateMap<Comment, CommentResponseDto>();
        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<UpdateCommentRequest, Comment>();
    }
}
