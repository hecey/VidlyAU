using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyAU.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}