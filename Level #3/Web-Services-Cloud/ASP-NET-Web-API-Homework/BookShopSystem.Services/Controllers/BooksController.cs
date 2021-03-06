﻿using Microsoft.AspNet.Identity;

namespace BookShopSystem.Services.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Models;
    using Data;

    public class BooksController : ApiController
    {
        private readonly BookShopSystemContext data;

        public BooksController(BookShopSystemContext context)
        {
            this.data = context;
        }

        public BooksController()
            :this(new BookShopSystemContext())
        {
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var book = this.data.Books
                .Select(b => new
                {
                    b.Id,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    b.Title,
                    b.Description,
                    b.EditionType,
                    b.Price,
                    b.Copies,
                    b.ReleaseDate,
                    b.AgeRestriction,
                    Categories = b.Categories.Select(c => c.Name)
                })
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Such book does not exist");
            }

            return this.Ok(book);
        }

        [HttpGet]
        public IHttpActionResult GetTopBooksBySearchWord(string search)
        {
            var books = this.data.Books
                .Where(b => b.Title.Contains(search))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    b.Id,
                    b.Title
                })
                .Take(10);

            return this.Ok(books);
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, UpdateBookBindingModel bookModel)
        {
            var book = this.data.Books
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Such book does not exist");
            }

            book.Title = bookModel.Title;
            book.Description = bookModel.Description;
            book.Price = bookModel.Price;
            book.Copies = bookModel.Copies;
            book.EditionType = bookModel.EditionType;
            book.AgeRestriction = bookModel.AgeRestriction;
            
            if (!string.IsNullOrEmpty(bookModel.ReleaseDate))
            {
                book.ReleaseDate = DateTime.Parse(bookModel.ReleaseDate, CultureInfo.InvariantCulture);
            }

            var author = this.data.Authors.FirstOrDefault(a => a.Id == bookModel.AuthorId);
            if (author == null)
            {
                return this.BadRequest("Such author does not exist");
            }

            book.Author = author;
            this.data.SaveChanges();
            return this.Ok("Book updated successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = this.data.Books
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Such book does not exist");
            }

            this.data.Books.Remove(book);
            this.data.SaveChanges();
            return this.Ok("Book removed successfully");
        }

        [HttpPost]
        public IHttpActionResult AddBook(PostBookBindingModel bookModel)
        {
            var book = new Book
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
                Price = bookModel.Price,
                Copies = bookModel.Copies,
                EditionType = bookModel.EditionType,
                AgeRestriction = bookModel.AgeRestriction,
            };

            if (!string.IsNullOrEmpty(bookModel.ReleaseDate))
            {
                book.ReleaseDate = DateTime.Parse(bookModel.ReleaseDate, CultureInfo.InvariantCulture);
            }

            var categoriesArr = bookModel.Categories.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var category in categoriesArr)
            {
                var categoryToAdd =
                    this.data.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Trim().ToLower());
                if (categoryToAdd != null)
                {
                    book.Categories.Add(categoryToAdd);
                }
            }

            this.data.Books.Add(book);
            this.data.SaveChanges();
            return this.Ok(book);
        }

        [HttpPut]
        [Authorize]
        [Route("api/books/buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            var book = this.data.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Such book does not exist");
            }

            if (book.Copies <= 0)
            {
                return this.BadRequest("No copies available");
            }
            var userId = this.User.Identity.GetUserId();
            var usersCount = this.data.Users.Count();
            var user = this.data.Users.FirstOrDefault(u => u.Id == userId);

            var purchase = new Purchase
            {
                Book = book,
                User = user,
                PurchaseDate = DateTime.Now,
                Price = book.Price
            };

            book.Copies--;

            this.data.Purchases.Add(purchase);

            this.data.SaveChanges();
            return this.Ok("Book bought successfully");
        }

        [HttpPut]
        [Authorize]
        [Route("api/books/recall/{id}")]
        public IHttpActionResult RecallBook(int id)
        {
            var purchase = this.data.Purchases.FirstOrDefault(p => p.Book.Id == id);

            if (purchase == null)
            {
                return this.BadRequest("Such book does not exist");
            }

            if ((DateTime.Now - purchase.PurchaseDate).TotalDays >= 30)
            {
                return this.BadRequest("30 days have passed since the purchase of the book");
            }

            var book = this.data.Books.First(b => b.Id == id);
            book.Copies++;
            purchase.IsRecalled = true;
            this.data.SaveChanges();
            return this.Ok("Book recalled successfully");
        }
    }
}
