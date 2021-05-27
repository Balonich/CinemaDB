using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Data;
using CinemaDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaDB.Pages.People
{
    public class DetailsModel : PageModel
    {
        private readonly IPersonRepository personRepository;
        public Person Person { get; set; }

        public DetailsModel(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IActionResult> OnGetAsync(int personId)
        {
            Person = await personRepository.GetPersonByIdAsync(personId);
            if (Person == null)
            {
                return RedirectToPage("NotFound");
            }
            PopulateCustomFilmography();
            return Page();
        }

        public void PopulateCustomFilmography()
        {
            Person.CustomFilmography = Person.Filmography.GroupBy(fg => fg.FilmID)
                                                         .Select(fg => new CustomFilmography
                                                         {
                                                             Film = fg.Select(x => x.Film).First(),
                                                             ProfessionsInFilm = String.Join(", ", fg.Select(x => x.Profession.Name)),
                                                             FilmReleaseDate = fg.Select(x => x.Film.ReleaseDate).First()
                                                         });
        }
    }
}