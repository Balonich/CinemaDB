using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public interface IFilmRepository
    {
        IEnumerable<Film> AllFilms { get; }
        Task<Film> GetFilmByIdAsync(int id);
        IEnumerable<Film> GetFilmByName(string name);
        Film Add(Film newFilm);
        Film Update(Film updatedFilm);
        Film Remove(int id);
        int Commit();
        Task<int> CommitAsync();
    }
}