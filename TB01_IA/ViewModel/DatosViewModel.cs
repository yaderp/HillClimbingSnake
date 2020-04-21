using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB01_IA.ViewModel
{
    public class DatosViewModel
    {
        public int ID { set; get; }
        public int Fila { set; get; }
        public int Columna { set; get; }
        public string Velocidad { set; get; }
        public string Nombre { set; get; }
        public DatosViewModel(int ID,string Velocidad)
        {
            this.ID = ID;
            this.Velocidad = Velocidad;
        }


        public DatosViewModel(int ID,int Columna, int Fila)
        {
            this.ID = ID;
            this.Fila = Fila;
            this.Columna = Columna;
            this.Nombre = "" + Columna * Variables.DIM + " x " + Fila * Variables.DIM;
        }
    }
}
