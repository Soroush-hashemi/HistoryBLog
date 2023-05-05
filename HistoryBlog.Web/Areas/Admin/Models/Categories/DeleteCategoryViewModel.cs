namespace TestBlog.Web.Areas.Admin.Models.Categories
{
    public class DeleteCategoryViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
    }
}
