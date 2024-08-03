using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class GenreServices : IGenreServices
    {
        private readonly DatabaseContext context;
        public GenreServices(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Genres model)
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
                context.Genres.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genres FindById(int id)
        {
            return context.Genres.Find(id);
        }

        public IEnumerable<Genres> GetALl()
        {
            return context.Genres.ToList();
        }

        public bool Update(Genres model)
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
