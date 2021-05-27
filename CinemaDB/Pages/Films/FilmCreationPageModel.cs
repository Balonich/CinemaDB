using System.Collections.Generic;
using System.Linq;
using CinemaDB.Data;
using CinemaDB.Models;
using CinemaDB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Pages.Films
{
    public class FilmCreationPageModel : PageModel
    {
        public List<AssignedGenresData> AssignedGenresDataList { get; set; }
        public SelectList CountriesSelectList { get; set; }

        public void PopulateAssignedGenresData(IGenreRepository genreRepository, Film film)
        {
            var allGenres = genreRepository.AllGenres;
            var filmGenres = new HashSet<int>(film.Genres.Select(g => g.ID));

            AssignedGenresDataList = new List<AssignedGenresData>();

            foreach (var genre in allGenres)
            {
                AssignedGenresDataList.Add(new AssignedGenresData
                {
                    GenreID = genre.ID,
                    Name = genre.Name,
                    Assigned = filmGenres.Contains(genre.ID)
                });
            }
        }

        public void PopulateCountriesSelectList(ICountryRepository countryRepository, object selectedCountry = null)
        {
            var countriesList = countryRepository.AllCountries.OrderBy(c => c.Name);

            CountriesSelectList = new SelectList(countriesList, "ID", "Name", selectedCountry);
        }
    }
}