using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Country> AllCountries => appDbContext.Countries;

        public Country GetCountryById(int id)
        {
            return appDbContext.Countries
                               .FirstOrDefault(c => c.ID == id);
        }
    }
}