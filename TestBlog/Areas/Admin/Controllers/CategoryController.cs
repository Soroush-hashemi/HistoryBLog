using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestBlog.Services.DTOs.Categories;
using TestBlog.Services.Services.Categories;
using TestBlog.Services.Utilities;
using TestBlog.Web.Areas.Admin.Models.Categories;

namespace TestBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        public IActionResult Add(int? parentId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int? parentId, CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());

            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = editModel.Slug,
                MetaTag = editModel.MetaTag,
                MetaDescription = editModel.MetaDescription,
                Title = editModel.Title,
                Id = id
            });

            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }

        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
                OperationResult.NotFound("Error");

            var categoryDelete = _categoryService.DeleteCategory(Id);
            SuccessAlert();
            return RedirectToAction("Index");
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var categoy = _categoryService.GetChildCategories(parentId);
            return new JsonResult(categoy);
        }
    }
}
