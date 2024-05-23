using CineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineApp.Dtos {
    public class Paginador<T> {
        public int TotalRegsTabla { get; set; }
        public int TotalRegsAMostrar { get; set; }
        public List<T> RegsAMostrar { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }

        public Paginador() { }

        public Paginador(int TotalRegsTabla, List<T> RegsAMostrar, int PaginaActual, int TotalRegsAMostrar) {
            this.TotalRegsTabla = TotalRegsTabla;
            this.RegsAMostrar = RegsAMostrar;
            this.PaginaActual = PaginaActual;
            this.TotalRegsAMostrar = TotalRegsAMostrar;
            this.TotalPaginas = (TotalRegsTabla % TotalRegsAMostrar) == 0 ? (TotalRegsTabla / TotalRegsAMostrar) : (TotalRegsTabla / TotalRegsAMostrar) + 1;
        }

    }
}