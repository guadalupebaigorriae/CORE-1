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
        
        static Listas()
        {
            ListaPeluquero = new List<Peluquero>();
        }

        public static List<Peluquero> ListaPeluquero { get => listaPeluquero; set => listaPeluquero = value; }
    }
}
