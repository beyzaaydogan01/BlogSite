
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService(
    ICategoryRepository _categoryRepository,
    IMapper _mapper) : ICategoryService
{
    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest request)
    {
        Category category = _mapper.Map<Category>(request);
        _categoryRepository.Add(category);
        CategoryResponseDto userResponseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = userResponseDto,
            Message = "User added",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest request)
    {
        Category category = _mapper.Map<Category>(request);
        _categoryRepository.Update(category);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = categoryResponseDto,
            Message = "Category updated",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Delete(int id)
    {
        Category? category = _categoryRepository.GetById(id);
        _categoryRepository.Remove(category);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = categoryResponseDto,
            Message = "Category deleted",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        Category? category = _categoryRepository.GetById(id);
        if (category == null)
        {
            return new ReturnModel<CategoryResponseDto?>()
            {
                Message = "Category not found",
                StatusCode = 404,
                Success = false
            };
        }

        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto?>()
        {
            Data = categoryResponseDto,
            Message = "Category retrieved",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> categoryResponseDtos = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = categoryResponseDtos,
            Message = "Categories retrieved",
            StatusCode = 200,
            Success = true
        };
    }
}
