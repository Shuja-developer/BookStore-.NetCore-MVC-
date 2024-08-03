using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class AuthorServices : IAuthorServices
    {
        private readonly DatabaseContext context;
        public AuthorServices(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Author model)
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
                context.Authors.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindById(int id)
        {
            return context.Authors.Find(id);
        }

        public IEnumerable<Author> GetALl()
        {
            return context.Authors.ToList();
        }

        public bool Update(Author model)
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

