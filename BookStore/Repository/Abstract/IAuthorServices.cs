﻿using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IAuthorServices
    {
        bool Add(Author model);
        bool Update(Author model);
        bool Delete(int id);
        Author FindById(int id);
        IEnumerable<Author> GetALl();
    }
}
