using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Listas
    {
        private static List<Peluquero> listaPeluquero;
        private static List<Turnos> listaTurnos;

        static Listas()
        {
            ListaPeluquero = new List<Peluquero>();
            ListaTurnos = new List<Turnos>();
        }

        public static List<Peluquero> ListaPeluquero { get => listaPeluquero; set => listaPeluquero = value; }
        public static List<Turnos> ListaTurnos { get => listaTurnos; set => listaTurnos = value; }
    }
}
