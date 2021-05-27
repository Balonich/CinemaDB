using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Middle Name")]
        public string MidName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Portrait Image")]
        public string PortraitImage { get; set; } = "https://m.media-amazon.com/images/S/sash/9FayPGLPcrscMjU.png";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [NotMapped]
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(MidName))
                {
                    return $"{FirstName} {LastName}";
                }
                else
                {
                    return $"{FirstName} {MidName} {LastName}";
                }
            }
        }

        [NotMapped]
        public IEnumerable<CustomFilmography> CustomFilmography { get; set; }

        [Required]
        public Country Country { get; set; }

        public ICollection<Filmography> Filmography { get; set; }
    }

    public class CustomFilmography
    {
        public Film Film { get; set; }
        public string ProfessionsInFilm { get; set; }
        public DateTime FilmReleaseDate { get; set; }
    }
}
