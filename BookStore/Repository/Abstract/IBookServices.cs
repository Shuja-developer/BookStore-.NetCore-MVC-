using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IBookServices
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book FindById(int id);
        IEnumerable<Book> GetALl();
    }
}
