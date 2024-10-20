
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using Core.Services;

namespace BlogSite.Service.Abstratcts;

public interface ICategoryService : IService<Category, int, CategoryResponseDto, CreateCategoryRequest, UpdateCategoryRequest>
{
}
