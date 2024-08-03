using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class BookServices : IBookServices
    {
        private readonly DatabaseContext context;
        public BookServices(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Book model)
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // Example: _logger.LogError(ex, "Error occurred while adding genre");
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Books.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetALl()
        {
            var data = (from book in context.Books
                        join author in context.Authors on book.AuthorId equals author.Id
                        join publisher in context.Publishers on book.PublisherId equals publisher.Id
                        join genre in context.Genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            Isbn = book.Isbn,
                            PublisherId = book.PublisherId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName

                        }
                     ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                context.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
