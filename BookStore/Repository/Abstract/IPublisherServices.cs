using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IPublisherServices
    {
        bool Add(Publisher model);
        bool Update(Publisher model);
        bool Delete(int id);
        Publisher FindById(int id);
        IEnumerable<Publisher> GetALl();
    }
}
