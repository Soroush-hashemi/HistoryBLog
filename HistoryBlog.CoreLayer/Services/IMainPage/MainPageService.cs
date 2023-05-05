using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.Services.Mappers;
using TestBlog.DataLayer.Context;
using TestBlog.DataLayer.Entities;
using TestBlog.Services.DTOs.MainPage;

namespace TestBlog.Services.Services.IMainPage
{
    public class MainPageService : IMainPageService
    {
        private readonly BlogContext _context;
        public MainPageService(BlogContext context)
        {
            _context = context;
        }

        public MainPageDto GetData()
        {
            var categories = _context.Categories
                .OrderByDescending(d => d.Id)
                .Take(8)
                .Include(p => p.Posts)
                .Include(p => p.SubPosts)
                .Select(category => new MainPageCategoryDto()
                {
                        IsMainCategory = category.ParentId == null,
                        PostChild = category.Posts.Count + category.SubPosts.Count,
                        Slug = category.Slug,
                        Title = category.Title

                }).ToList();
            
            var specialPosts = _context.Posts
                .OrderByDescending(p => p.Id)
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .Where(s => s.IsSpecial).Take(4)
                .Select(post => PostMapper.MapToDto(post)).ToList();


            var latestPost = _context.Posts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .OrderByDescending(d => d.Id)
                .Take(6)
                .Select(post => PostMapper.MapToDto(post)).ToList();

            return new MainPageDto()
            {
                Categories = categories,
                LatestPosts = latestPost,
                SpecialPosts = specialPosts
            };

        }
    }
}
