using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Data;
using CinemaDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace CinemaDB.Pages.Films
{
    public class CreateModel : FilmCreationPageModel
    {
        private readonly IFilmRepository filmRepository;
        private readonly IGenreRepository genreRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ILogger<FilmCreationPageModel> logger;

        [BindProperty]
        public Film Film { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public CreateModel(IFilmRepository filmRepository,
                           IGenreRepository genreRepository,
                           ICountryRepository countryRepository,
                           ILogger<FilmCreationPageModel> logger)
        {
            this.countryRepository = countryRepository;
            this.filmRepository = filmRepository;
            this.genreRepository = genreRepository;
            this.logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int? filmId)
        {
            Genres = genreRepository.AllGenres;
            ViewData["Genres"] = new SelectList(Genres, "ID", "Name");
            if (filmId.HasValue)
            {
                Film = await filmRepository.GetFilmByIdAsync(filmId.Value);
            }
            else
            {
                Film = new Film();
            }

            if (Film == null)
            {
                return RedirectToPage("NotFound");
            }

            PopulateAssignedGenresData(genreRepository, Film);
            PopulateCountriesSelectList(countryRepository, Film.Country?.ID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            Film filmToUpdate;

            if (!ModelState.IsValid)
            {
                PopulateAssignedGenresData(genreRepository, Film);
                PopulateCountriesSelectList(countryRepository, Film.Country.ID);
                return Page();
            }

            /*
            NOTE: before the next 'if' implementation i've tried to clear the list of genres in bind property, then to update this model
            but this method doesn't work because binded property is not linked to the value from db, it also doesn't
            have the connection with genres table, in this case you have to get the film from db, update genres list
            and only then update the film, more info: https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-ef-core-5-and-above/
            Also I think that it is bad to clear the whole genres list and populate it with date QUESTION:?
            */
            if (Film.ID > 0)
            {
                filmToUpdate = await filmRepository.GetFilmByIdAsync(Film.ID);
                UpdateFilmGenres(selectedGenres, ref filmToUpdate);
                UpdateFilmCountry(Film.Country.ID, ref filmToUpdate);
                filmRepository.Update(filmToUpdate);
            }
            else
            {
                filmToUpdate = Film;
                UpdateFilmGenres(selectedGenres, ref filmToUpdate);
                filmRepository.Add(filmToUpdate);
            }

            await filmRepository.CommitAsync();

            return RedirectToPage("./Details", new { filmId = filmToUpdate.ID });
        }

        private void UpdateFilmCountry(int countryID, ref Film filmToUpdate)
        {
            filmToUpdate.Country = countryRepository.GetCountryById(countryID);
        }

        // QUESTION: it is better to return Film, to add ref param, to create extension method or to create method in View?
        private void UpdateFilmGenres(string[] selectedGenres, ref Film filmToUpdate)
        {
            filmToUpdate.Genres.Clear();
            foreach (var genre in selectedGenres)
            {
                var foundGenre = genreRepository.GetGenreById(int.Parse(genre));

                if (foundGenre != null)
                {
                    filmToUpdate.Genres.Add(foundGenre);
                }
                else
                {
                    logger.LogWarning("Genre {genre} not found", genre);
                }
            }
        }
    }
}