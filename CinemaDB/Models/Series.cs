using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaDB.Models
{
    [Table("Series")]
    public class Series : Film
    {
        public int SeasonsCount { get; set; }
        public List<Episode> Episodes { get; set; }
        public bool Ongoing { get; set; }
    }
}