using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Data;
using CinemaDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaDB.Pages.Films
{
    public class ListModel : PageModel
    {
        private readonly IFilmRepository filmRepository;
        public IEnumerable<Film> Films { get; set; }
        public string CurrentFilter { get; set; }

        public ListModel(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        public async Task OnGetAsync(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                Films = filmRepository.AllFilms;
            }
            else
            {
                Films = filmRepository.GetFilmByName(searchString);
            }
        }
    }
}