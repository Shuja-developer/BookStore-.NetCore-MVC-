using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class PublisherServices:IPublisherServices
    {
        private readonly DatabaseContext context;
        public PublisherServices(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Publisher model)
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
                context.Publishers.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return context.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetALl()
        {
            return context.Publishers.ToList();
        }

        public bool Update(Publisher model)
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
