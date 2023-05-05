using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlog.Services.DTOs.Comments;
using TestBlog.Services.Utilities;
using TestBlog.DataLayer.Context;
using TestBlog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestBlog.Services.Services.Comments
{
    public interface ICommentService
    {
        OperationResult CreateComment(CreateCommentDto command);
        List<CommentDto> GetPostComments(int postId);
    }
}
