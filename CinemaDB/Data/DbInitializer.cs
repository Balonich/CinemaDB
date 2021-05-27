using System;
using System.Linq;
using CinemaDB.Models;

namespace CinemaDB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Films.Any())
            {
                return;
            }

            // https://gist.github.com/adhipg/1600028
            Country[] CountriesStartingSet =
            {
                new Country { Name = "Afghanistan" },
                new Country { Name = "Albania" },
                new Country { Name = "Algeria" },
                new Country { Name = "American Samoa" },
                new Country { Name = "Andorra" },
                new Country { Name = "Angola" },
                new Country { Name = "Anguilla" },
                new Country { Name = "Antarctica" },
                new Country { Name = "Antigua and Barbuda" },
                new Country { Name = "Argentina" },
                new Country { Name = "Armenia" },
                new Country { Name = "Aruba" },
                new Country { Name = "Australia" },
                new Country { Name = "Austria" },
                new Country { Name = "Azerbaijan" },
                new Country { Name = "Bahamas" },
                new Country { Name = "Bahrain" },
                new Country { Name = "Bangladesh" },
                new Country { Name = "Barbados" },
                new Country { Name = "Belarus" },
                new Country { Name = "Belgium" },
                new Country { Name = "Belize" },
                new Country { Name = "Benin" },
                new Country { Name = "Bermuda" },
                new Country { Name = "Bhutan" },
                new Country { Name = "Bolivia" },
                new Country { Name = "Bosnia and Herzegovina" },
                new Country { Name = "Botswana" },
                new Country { Name = "Bouvet Island" },
                new Country { Name = "Brazil" },
                new Country { Name = "British Indian Ocean Territory" },
                new Country { Name = "Brunei Darussalam" },
                new Country { Name = "Bulgaria" },
                new Country { Name = "Burkina Faso" },
                new Country { Name = "Burundi" },
                new Country { Name = "Cambodia" },
                new Country { Name = "Cameroon" },
                new Country { Name = "Canada" },
                new Country { Name = "Cape Verde" },
                new Country { Name = "Cayman Islands" },
                new Country { Name = "Central African Republic" },
                new Country { Name = "Chad" },
                new Country { Name = "Chile" },
                new Country { Name = "China" },
                new Country { Name = "Christmas Island" },
                new Country { Name = "Cocos (Keeling) Islands" },
                new Country { Name = "Colombia" },
                new Country { Name = "Comoros" },
                new Country { Name = "Congo" },
                new Country { Name = "Congo, the Democratic Republic of the" },
                new Country { Name = "Cook Islands" },
                new Country { Name = "Costa Rica" },
                new Country { Name = "Cote D'Ivoire" },
                new Country { Name = "Croatia" },
                new Country { Name = "Cuba" },
                new Country { Name = "Cyprus" },
                new Country { Name = "Czech Republic" },
                new Country { Name = "Denmark" },
                new Country { Name = "Djibouti" },
                new Country { Name = "Dominica" },
                new Country { Name = "Dominican Republic" },
                new Country { Name = "Ecuador" },
                new Country { Name = "Egypt" },
                new Country { Name = "El Salvador" },
                new Country { Name = "Equatorial Guinea" },
                new Country { Name = "Eritrea" },
                new Country { Name = "Estonia" },
                new Country { Name = "Ethiopia" },
                new Country { Name = "Falkland Islands (Malvinas)" },
                new Country { Name = "Faroe Islands" },
                new Country { Name = "Fiji" },
                new Country { Name = "Finland" },
                new Country { Name = "France" },
                new Country { Name = "French Guiana" },
                new Country { Name = "French Polynesia" },
                new Country { Name = "French Southern Territories" },
                new Country { Name = "Gabon" },
                new Country { Name = "Gambia" },
                new Country { Name = "Georgia" },
                new Country { Name = "Germany" },
                new Country { Name = "Ghana" },
                new Country { Name = "Gibraltar" },
                new Country { Name = "Greece" },
                new Country { Name = "Greenland" },
                new Country { Name = "Grenada" },
                new Country { Name = "Guadeloupe" },
                new Country { Name = "Guam" },
                new Country { Name = "Guatemala" },
                new Country { Name = "Guinea" },
                new Country { Name = "Guinea-Bissau" },
                new Country { Name = "Guyana" },
                new Country { Name = "Haiti" },
                new Country { Name = "Heard Island and Mcdonald Islands" },
                new Country { Name = "Holy See (Vatican City State)" },
                new Country { Name = "Honduras" },
                new Country { Name = "Hong Kong" },
                new Country { Name = "Hungary" },
                new Country { Name = "Iceland" },
                new Country { Name = "India" },
                new Country { Name = "Indonesia" },
                new Country { Name = "Iran" },
                new Country { Name = "Iraq" },
                new Country { Name = "Ireland" },
                new Country { Name = "Israel" },
                new Country { Name = "Italy" },
                new Country { Name = "Jamaica" },
                new Country { Name = "Japan" },
                new Country { Name = "Jordan" },
                new Country { Name = "Kazakhstan" },
                new Country { Name = "Kenya" },
                new Country { Name = "Kiribati" },
                new Country { Name = "Korea, Democratic People's Republic of" },
                new Country { Name = "Korea, Republic of" },
                new Country { Name = "Kuwait" },
                new Country { Name = "Kyrgyzstan" },
                new Country { Name = "Lao People's Democratic Republic" },
                new Country { Name = "Latvia" },
                new Country { Name = "Lebanon" },
                new Country { Name = "Lesotho" },
                new Country { Name = "Liberia" },
                new Country { Name = "Libyan Arab Jamahiriya" },
                new Country { Name = "Liechtenstein" },
                new Country { Name = "Lithuania" },
                new Country { Name = "Luxembourg" },
                new Country { Name = "Macao" },
                new Country { Name = "Macedonia" },
                new Country { Name = "Madagascar" },
                new Country { Name = "Malawi" },
                new Country { Name = "Malaysia" },
                new Country { Name = "Maldives" },
                new Country { Name = "Mali" },
                new Country { Name = "Malta" },
                new Country { Name = "Marshall Islands" },
                new Country { Name = "Martinique" },
                new Country { Name = "Mauritania" },
                new Country { Name = "Mauritius" },
                new Country { Name = "Mayotte" },
                new Country { Name = "Mexico" },
                new Country { Name = "Micronesia" },
                new Country { Name = "Moldova" },
                new Country { Name = "Monaco" },
                new Country { Name = "Mongolia" },
                new Country { Name = "Montserrat" },
                new Country { Name = "Morocco" },
                new Country { Name = "Mozambique" },
                new Country { Name = "Myanmar" },
                new Country { Name = "Namibia" },
                new Country { Name = "Nauru" },
                new Country { Name = "Nepal" },
                new Country { Name = "Netherlands" },
                new Country { Name = "Netherlands Antilles" },
                new Country { Name = "New Caledonia" },
                new Country { Name = "New Zealand" },
                new Country { Name = "Nicaragua" },
                new Country { Name = "Niger" },
                new Country { Name = "Nigeria" },
                new Country { Name = "Niue" },
                new Country { Name = "Norfolk Island" },
                new Country { Name = "Northern Mariana Islands" },
                new Country { Name = "Norway" },
                new Country { Name = "Oman" },
                new Country { Name = "Pakistan" },
                new Country { Name = "Palau" },
                new Country { Name = "Palestinian Territory, Occupied" },
                new Country { Name = "Panama" },
                new Country { Name = "Papua New Guinea" },
                new Country { Name = "Paraguay" },
                new Country { Name = "Peru" },
                new Country { Name = "Philippines" },
                new Country { Name = "Pitcairn" },
                new Country { Name = "Poland" },
                new Country { Name = "Portugal" },
                new Country { Name = "Puerto Rico" },
                new Country { Name = "Qatar" },
                new Country { Name = "Reunion" },
                new Country { Name = "Romania" },
                new Country { Name = "Russian Federation" },
                new Country { Name = "Rwanda" },
                new Country { Name = "Saint Helena" },
                new Country { Name = "Saint Kitts and Nevis" },
                new Country { Name = "Saint Lucia" },
                new Country { Name = "Saint Pierre and Miquelon" },
                new Country { Name = "Saint Vincent and the Grenadines" },
                new Country { Name = "Samoa" },
                new Country { Name = "San Marino" },
                new Country { Name = "Sao Tome and Principe" },
                new Country { Name = "Saudi Arabia" },
                new Country { Name = "Senegal" },
                new Country { Name = "Serbia and Montenegro" },
                new Country { Name = "Seychelles" },
                new Country { Name = "Sierra Leone" },
                new Country { Name = "Singapore" },
                new Country { Name = "Slovakia" },
                new Country { Name = "Slovenia" },
                new Country { Name = "Solomon Islands" },
                new Country { Name = "Somalia" },
                new Country { Name = "South Africa" },
                new Country { Name = "South Georgia and the South Sandwich Islands" },
                new Country { Name = "Spain" },
                new Country { Name = "Sri Lanka" },
                new Country { Name = "Sudan" },
                new Country { Name = "Suriname" },
                new Country { Name = "Svalbard and Jan Mayen" },
                new Country { Name = "Swaziland" },
                new Country { Name = "Sweden" },
                new Country { Name = "Switzerland" },
                new Country { Name = "Syrian Arab Republic" },
                new Country { Name = "Taiwan, Province of China" },
                new Country { Name = "Tajikistan" },
                new Country { Name = "Tanzania" },
                new Country { Name = "Thailand" },
                new Country { Name = "Timor-Leste" },
                new Country { Name = "Togo" },
                new Country { Name = "Tokelau" },
                new Country { Name = "Tonga" },
                new Country { Name = "Trinidad and Tobago" },
                new Country { Name = "Tunisia" },
                new Country { Name = "Turkey" },
                new Country { Name = "Turkmenistan" },
                new Country { Name = "Turks and Caicos Islands" },
                new Country { Name = "Tuvalu" },
                new Country { Name = "Uganda" },
                new Country { Name = "Ukraine" },
                new Country { Name = "United Arab Emirates" },
                new Country { Name = "United Kingdom" },
                new Country { Name = "United States" },
                new Country { Name = "United States Minor Outlying Islands" },
                new Country { Name = "Uruguay" },
                new Country { Name = "Uzbekistan" },
                new Country { Name = "Vanuatu" },
                new Country { Name = "Venezuela" },
                new Country { Name = "Viet Nam" },
                new Country { Name = "Virgin Islands, British" },
                new Country { Name = "Virgin Islands, U.S."} ,
                new Country { Name = "Wallis and Futuna" },
                new Country { Name = "Western Sahara" },
                new Country { Name = "Yemen" },
                new Country { Name = "Zambia" },
                new Country { Name = "Zimbabwe" }
            };

            context.AddRange(CountriesStartingSet);

            Genre[] GenresStartingSet =
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Adventure" },
                new Genre { Name = "Animation" },
                new Genre { Name = "Biography" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Crime" },
                new Genre { Name = "Documentary" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Family" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Film-Noir" },
                new Genre { Name = "History" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Music" },
                new Genre { Name = "Musical" },
                new Genre { Name = "Mystery" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Short" },
                new Genre { Name = "Sport" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "War" },
                new Genre { Name = "Western" }
            };

            context.AddRange(GenresStartingSet);

            Film[] FilmsStartingSet =
            {
                new Film
                {
                    Title = "Nobody",
                    Description = "A bystander who intervenes to help a woman being harassed by a group of men becomes the target of a vengeful drug lord.",
                    ThumbnailImage = "https://m.media-amazon.com/images/M/MV5BMjJiYjdjNWEtODNiMS00MTBiLWE4NTAtNGNjMDgxZWQzMTgyXkEyXkFqcGdeQXVyMTA3MDk2NDg2._V1_.jpg",
                    ReleaseDate = new DateTime(2021, 3, 18),
                    Budget = 16000000.0m,
                    AgeRestriction = "18+",
                    Country = CountriesStartingSet[225],
                    Genres = { GenresStartingSet[0], GenresStartingSet[5] }
                },
                new Film
                {
                    Title = "Avengers: Endgame",
                    Description = "After the devastating events of Avengers: Infinite War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                    ThumbnailImage = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_.jpg",
                    ReleaseDate = new DateTime(2019, 4, 29),
                    Budget = 356000000.0m,
                    AgeRestriction = "16+",
                    Country = CountriesStartingSet[225],
                    Genres = { GenresStartingSet[0], GenresStartingSet[1], GenresStartingSet[17] }
                },
                new Film
                {
                    Title = "Tenet",
                    Description = "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.",
                    ThumbnailImage = "https://m.media-amazon.com/images/M/MV5BYzg0NGM2NjAtNmIxOC00MDJmLTg5ZmYtYzM0MTE4NWE2NzlhXkEyXkFqcGdeQXVyMTA4NjE0NjEy._V1_.jpg",
                    ReleaseDate = new DateTime(2020, 9, 3),
                    Budget = 205000000.0m,
                    AgeRestriction = "16+",
                    Country = CountriesStartingSet[224],
                    Genres = { GenresStartingSet[0], GenresStartingSet[17] }
                },
                new Film
                {
                    Title = "Druk",
                    Description = "Four high school teachers consume alcohol on a daily basis to see how it affects their social and professional lives.",
                    ThumbnailImage = "https://m.media-amazon.com/images/M/MV5BOTNjM2Y2ZjgtMDc5NS00MDQ1LTgyNGYtYzYwMTAyNWQwYTMyXkEyXkFqcGdeQXVyMjE4NzUxNDA@._V1_.jpg",
                    ReleaseDate = new DateTime(2020, 11, 12),
                    Budget = 4000000.0m,
                    AgeRestriction = "16+",
                    Country = CountriesStartingSet[57],
                    Genres = { GenresStartingSet[4], GenresStartingSet[7] }
                },
                new Film
                {
                    Title = "Soul",
                    Description = "After landing the gig of a lifetime, a New York jazz pianist suddenly finds himself trapped in a strange land between Earth and the afterlife.",
                    ThumbnailImage = "https://m.media-amazon.com/images/M/MV5BZGE1MDg5M2MtNTkyZS00MTY5LTg1YzUtZTlhZmM1Y2EwNmFmXkEyXkFqcGdeQXVyNjA3OTI0MDc@._V1_.jpg",
                    ReleaseDate = new DateTime(2021, 1, 21),
                    Budget = 15000000.0m,
                    AgeRestriction = "6+",
                    Country = CountriesStartingSet[225],
                    Genres = { GenresStartingSet[2], GenresStartingSet[8], GenresStartingSet[9], GenresStartingSet[13] }
                }
            };

            context.AddRange(FilmsStartingSet);

            Profession[] ProfessionsStartingSet =
            {
                new Profession
                {
                    Name = "Actor/Actress"
                },
                new Profession
                {
                    Name = "Writer"
                },
                new Profession
                {
                    Name = "Director"
                },
                new Profession
                {
                    Name = "Producer"
                },
                new Profession
                {
                    Name = "Musician"
                }
            };

            Person[] PeopleStartingSet =
            {
                new Person
                {
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    DateOfBirth = new DateTime(1970, 07, 30),
                    Country = CountriesStartingSet[224],
                    PortraitImage = "https://m.media-amazon.com/images/M/MV5BNjE3NDQyOTYyMV5BMl5BanBnXkFtZTcwODcyODU2Mw@@._V1_.jpg",
                },
            };

            Filmography[] FilmographyStartingSet =
            {
                new Filmography
                {
                    Film = FilmsStartingSet[2],
                    Profession = ProfessionsStartingSet[1],
                    Person = PeopleStartingSet[0]
                },
                new Filmography
                {
                    Film = FilmsStartingSet[2],
                    Profession = ProfessionsStartingSet[2],
                    Person = PeopleStartingSet[0]
                },
                new Filmography
                {
                    Film = FilmsStartingSet[2],
                    Profession = ProfessionsStartingSet[3],
                    Person = PeopleStartingSet[0]
                },
                new Filmography
                {
                    Film = FilmsStartingSet[3],
                    Profession = ProfessionsStartingSet[3],
                    Person = PeopleStartingSet[0]
                },
            };

            context.AddRange(ProfessionsStartingSet);
            context.AddRange(PeopleStartingSet);
            context.AddRange(FilmographyStartingSet);

            context.SaveChanges();
        }
    }
}