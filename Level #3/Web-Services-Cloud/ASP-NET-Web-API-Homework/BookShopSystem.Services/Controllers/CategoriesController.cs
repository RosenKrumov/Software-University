using System.Linq;
using BookShopSystem.Models;
using BookShopSystem.Services.Models;

namespace BookShopSystem.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class CategoriesController : ApiController
    {
        private readonly BookShopSystemContext data;

        public CategoriesController(BookShopSystemContext context)
        {
            this.data = context;
        }

        public CategoriesController()
            :this(new BookShopSystemContext())
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            var categories = this.data.Categories
                .Select(c => new
                {
                    c.Id,
                    c.Name
                });

            return this.Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = this.data.Categories
                .Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.BadRequest("Such category does not exist");
            }

            return this.Ok(category);
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, CategoryBindingModel categoryModel)
        {
            var category = this.data.Categories
                .FirstOrDefault(c => c.Id == id);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            category.Name = categoryModel.Name;
            this.data.SaveChanges();
            return this.Ok("Category edited successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = this.data.Categories
                   .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.BadRequest("Such category does not exist");
            }

            this.data.Categories.Remove(category);
            this.data.SaveChanges();
            return this.Ok("Category removed successfully");
        }

        [HttpPost]
        public IHttpActionResult AddCategory(CategoryBindingModel categoryModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = new Category{Name = categoryModel.Name};
            this.data.Categories.Add(category);
            this.data.SaveChanges();
            return this.Ok(category);
        }
    }
}
