namespace BookShopSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Models;
    using Data;

    public class AuthorsController : ApiController
    {
        private readonly BookShopSystemContext data;

        public AuthorsController(BookShopSystemContext context)
        {
            this.data = context;
        }

        public AuthorsController()
            :this(new BookShopSystemContext())
        {
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = this.data.Authors
                .Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                    Books = a.Books.Select(b => b.Title)
                })
                .FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return this.BadRequest("Such author does not exist");
            }

            return this.Ok(author);
        }

        [HttpPost]
        public IHttpActionResult AddAuthor(AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var authorToAdd = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            this.data.Authors.Add(authorToAdd);
            this.data.SaveChanges();
            return this.Ok(authorToAdd);
        }

        [HttpGet]
        [Route("api/authors/{id}/books")]
        public IHttpActionResult GetAuthorBooks(int id)
        {
            var booksByAuthor = this.data.Books
                .Where(b => b.Author.Id == id)
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Description,
                    b.EditionType,
                    b.Price,
                    b.Copies,
                    b.ReleaseDate,
                    b.AgeRestriction,
                    Categories = b.Categories.Select(c => c.Name)
                });

            return this.Ok(booksByAuthor);
        }
    }
}
