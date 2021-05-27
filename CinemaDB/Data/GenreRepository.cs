using System.Collections.Generic;
using System.Linq;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Genre> AllGenres => appDbContext.Genres;

        public Genre Add(Genre newGenre)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public Genre GetGenreById(int id)
        {
            return appDbContext.Genres.FirstOrDefault(g => g.ID == id);
        }

        public IEnumerable<Genre> GetGenreByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Genre Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Genre Update(Genre updatedGenre)
        {
            throw new System.NotImplementedException();
        }
    }
}