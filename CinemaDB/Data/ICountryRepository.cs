using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries { get; }
        Country GetCountryById(int id);
    }
}