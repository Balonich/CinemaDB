using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext appDbContext;

        public FilmRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Film> AllFilms => appDbContext.Films
                                                         .Include(f => f.Genres);

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await appDbContext.Films
                                     .Include(f => f.Genres)
                                     .Include(f => f.Country)
                                     .FirstOrDefaultAsync(f => f.ID == id);
        }

        public IEnumerable<Film> GetFilmByName(string name)
        {
            return from f in AllFilms
                   where f.Title.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby f.Title
                   select f;
        }

        public Film Add(Film newFilm)
        {
            appDbContext.Films.Add(newFilm);
            return newFilm;
        }

        public Film Remove(int id)
        {
            var film = GetFilmByIdAsync(id).Result;
            if (film != null)
            {
                appDbContext.Films.Remove(film);
            }
            return film;
        }

        public Film Update(Film updatedFilm)
        {
            var entity = appDbContext.Films.Attach(updatedFilm);
            entity.State = EntityState.Modified;
            return updatedFilm;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }
    }
}