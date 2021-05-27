using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaDB.Models
{
    public class Film
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Thumbnail Image")]
        public string ThumbnailImage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        [NotMapped]
        public string GenresString { get => String.Join(", ", Genres.ConvertAll(g => g.Name)); }

        public Studio Studio { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "Age Restriction")]
        public string AgeRestriction { get; set; }

        public ICollection<Filmography> People { get; set; }
    }
}
