using System.Collections.Generic;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> AllGenres { get; }
        Genre GetGenreById(int id);
        IEnumerable<Genre> GetGenreByName(string name);
        Genre Add(Genre newGenre);
        Genre Update(Genre updatedGenre);
        Genre Remove(int id);
        int Commit();
    }
}