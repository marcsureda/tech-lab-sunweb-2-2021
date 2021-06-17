using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AuthorRepository
    {
        private readonly List<Author> _authors =
            new List<Author>();

        private readonly List<BlogPost> _posts =
            new List<BlogPost>();

        public AuthorRepository()
        {
            var author1 = new Author
            {
                Id = 1,
                FirstName = "Joydip",
                LastName = "Kanjilal"
            };
            var author2 = new Author
            {
                Id = 2,
                FirstName = "Steve",
                LastName = "Smith"
            };
            var csharp = new BlogPost
            {
                Id = 1,
                Title = "Mastering C#",
                Content = "This is a series of articles on C#.",
                Author = author1
            };
            var java = new BlogPost
            {
                Id = 2,
                Title = "Mastering Java",
                Content = "This is a series of articles on Java",
                Author = author1
            };
            _posts.Add(csharp);
            _posts.Add(java);
            _authors.Add(author1);
            _authors.Add(author2);
        }

        public List<Author> GetAllAuthors()
        {
            return _authors;
        }

        public Author GetAuthorById(int id)
        {
            return _authors.FirstOrDefault(author => author.Id == id);
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _posts.Where(post => post.Author.Id == id).ToList();
        }
    }
}