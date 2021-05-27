using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaDB.Models
{
    public class Filmography
    {
        public int FilmID { get; set; }
        public int ProfessionID { get; set; }
        public int PersonID { get; set; }


        public Film Film { get; set; }
        public Profession Profession { get; set; }
        public Person Person { get; set; }
    }
}