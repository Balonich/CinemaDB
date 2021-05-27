using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Studio
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LogoImage { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png";
        public List<Film> PublishedFilms { get; set; }
        // public List<Series> PublisedSeries { get; set; }
    }
}
