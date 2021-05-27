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
    public class DetailsModel : PageModel
    {
        private readonly IFilmRepository filmRepository;
        public Film Film { get; set; }

        public DetailsModel(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        public async Task<IActionResult> OnGetAsync(int filmId)
        {
            Film = await filmRepository.GetFilmByIdAsync(filmId);
            if (Film == null)
            {
                return RedirectToAction("NotFound");
            }
            
            return Page();
        }
    }
}