using System;
using System.ComponentModel.DataAnnotations;
namespace Final_Group_Project.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieID { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string ReleaseDate { get; set; }
        public int IMDbscore { get; set; }

    }
}

