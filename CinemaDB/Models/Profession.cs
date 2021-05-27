using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Profession
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Filmography> Filmography { get; set; }
    }
}
