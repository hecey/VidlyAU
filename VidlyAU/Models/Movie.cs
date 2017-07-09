﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAU.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name ="Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        public Genre Genres { get; set; }

        [Display(Name = "Genre")]
        public byte GenresId { get; set; }

    }
}