using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineApp.Models {
    public class Pelicula {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }  
        public decimal Ranking { get; set; }
        public string Poster { get; set; }
    }
}