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
    public class ListModel : PageModel
    {
        private readonly IPersonRepository personRepository;
        public IEnumerable<Person> People { get; set; }
        public string CurrentFilter { get; set; }

        public ListModel(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task OnGetAsync(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                People = personRepository.AllPeople;
            }
            else
            {
                People = personRepository.GetPersonByName(searchString);
            }
        }
    }
}