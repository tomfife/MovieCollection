using System;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class AddMovieResponse
    {
        [Key]
        public int MovieID { get;  set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo  { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}

//    Category,
//    Title,
//    Year,
//    Director,
//    Rating - dropdown menu(G, PG, PG - 13, R),
//    Edited - yes / no(true / false) option,
//    Lent To,
//    Notes - limited to 25 characters

//    The “Edited”, “Lent To”, and “Notes” fields are optional. All other fields must be entered.
//