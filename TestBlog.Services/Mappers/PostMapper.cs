using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.DataLayer.Entities;
using TestBlog.Services.DTOs.Posts;
using TestBlog.Services.Utilities;

namespace TestBlog.Services.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug.ToSlug(),
                Title = dto.Title,
                UserId = dto.UserId,
                Visit = 0,
                IsDelete = false,
                SubCategoryId = dto.SubCategoryId
            };
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserFullName = post.User?.FullName,
                Visit = post.Visit,
                CreationDate = post.CreationDate,
                Category = post.Category == null ? null : CategoryMapper.Map(post.Category),
                ImageName = post.ImageName,
                PostId = post.Id,
                SubCategoryId = post.SubCategoryId,
                SubCategory = post.SubCategory == null ? null : CategoryMapper.Map(post.SubCategory),
                //IsSpecial = post.IsSpecial
            };
        }
        public static Post EditPost(EditPostDto editDto, Post post)
        {
            post.Description = editDto.Description;
            post.Title = editDto.Title;
            post.CategoryId = editDto.CategoryId;
            post.Slug = editDto.Slug.ToSlug();
            post.SubCategoryId = editDto.SubCategoryId;
            return post;
        }
    }
}
