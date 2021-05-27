using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public interface IPersonRepository
    {
        IEnumerable<Person> AllPeople { get; }
        Task<Person> GetPersonByIdAsync(int id);
        IEnumerable<Person> GetPersonByName(string name);
        Person Add(Person newPerson);
        Person Update(Person updatedPerson);
        Person Remove(int id);
        int Commit();
        Task<int> CommitAsync();
    }
}