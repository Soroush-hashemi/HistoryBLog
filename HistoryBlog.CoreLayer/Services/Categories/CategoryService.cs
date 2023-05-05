﻿using TestBlog.DataLayer.Context;
using TestBlog.DataLayer.Entities;
using TestBlog.Services.DTOs.Categories;
using TestBlog.Services.Mappers;
using TestBlog.Services.Utilities;

namespace TestBlog.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            if (command.Title == null)
                return OperationResult.Error(/*"وارد کردن عنوان اجباری است"*/);

            if (command.Slug == null)
                return OperationResult.Error(/*"وارد کردن slug اجباری است"*/);

            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");

            var category = new Category()
            {
                Title = command.Title,
                IsDelete = false,
                ParentId = command.ParentId,
                Slug = command.Slug.ToSlug(),
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult DeleteCategory(int categoryDeleteId)
        {
            var DeleteCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryDeleteId);
            _context.Remove(DeleteCategory);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
            if (command.Title == null)
                return OperationResult.Error(/*"وارد کردن عنوان اجباری است"*/);

            if (command.Slug == null)
                return OperationResult.Error(/*"وارد کردن slug اجباری است"*/);

            var category = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            if (category == null)
                return OperationResult.NotFound();

            if (command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("Slug Is Exist");

            category.MetaDescription = command.MetaDescription;
            category.Slug = command.Slug.ToSlug();
            category.Title = command.Title;
            category.MetaTag = command.MetaTag;

            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(category => CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public List<CategoryDto> GetChildCategories(int parentId)
        {
            return _context.Categories.Where(r => r.ParentId == parentId)
                .Select(category => CategoryMapper.Map(category)).ToList();
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
