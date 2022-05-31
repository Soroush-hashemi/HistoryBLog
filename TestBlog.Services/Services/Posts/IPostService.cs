using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.Services.DTOs.Posts;
using TestBlog.Services.Utilities;

namespace TestBlog.Services.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);
        OperationResult EditPost(EditPostDto command);
        OperationResult DeletePost(int PostDeleteId);
        PostDto GetPostById(int postId);
        PostDto GetPostBySlug(string slug);
        PostFilterDto GetPostsByFilter(PostFilterParams filterParams);
        bool IsSlugExist(string slug);
        List<PostDto> GetRelatedPosts(int CategoryId);
        List<PostDto> GetPopularPost();
        void IncreaseVisit(int postId);
    }
}
