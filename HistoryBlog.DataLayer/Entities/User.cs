using System.ComponentModel.DataAnnotations;

namespace TestBlog.DataLayer.Entities
{
    public class User : BaseEntity<long>
    {
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        #region Relations
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion
    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
