using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Person> AllPeople => appDbContext.People
                                                            .Include(p => p.Filmography)
                                                                .ThenInclude(fg => fg.Profession)
                                                            .Include(p => p.Filmography)
                                                                .ThenInclude(fg => fg.Film);

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await appDbContext.People
                                     .Include(p => p.Filmography)
                                         .ThenInclude(fg => fg.Profession)
                                     .Include(p => p.Filmography)
                                         .ThenInclude(fg => fg.Film)
                                     .Include(p => p.Country)
                                     .FirstOrDefaultAsync(p => p.ID == id);
        }

        public IEnumerable<Person> GetPersonByName(string name)
        {
            return from p in AllPeople
                   where p.FullName.StartsWith(name) || p.FullName.Contains(name) || string.IsNullOrEmpty(name)
                   orderby p.FirstName
                   select p;
        }
        public Person Add(Person newPerson)
        {
            appDbContext.People.Add(newPerson);
            return newPerson;
        }

        public Person Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person Update(Person updatedPerson)
        {
            var entity = appDbContext.People.Attach(updatedPerson);
            entity.State = EntityState.Modified;
            return updatedPerson;
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