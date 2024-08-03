using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IGenreServices
    {
        bool Add(Genres model);
        bool Update(Genres model);
        bool Delete(int id);
        Genres FindById(int id);
        IEnumerable<Genres> GetALl();

    }
}
