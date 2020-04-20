using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TB1.ViewModel
{
    public class MapaViewModel
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Tipo { set; get; }
        public int PosXY { set; get; }
        public int Distancia { set; get; }
        public int Direccion { set; get; }
        public int Espacio { set; get; }


        public MapaViewModel(int X, int Y,int Direccion) {
            this.X = X;
            this.Y = Y;
            this.Direccion = Direccion;
            this.PosXY = Y * Variables.COLUMNA + X;
            this.Distancia = 0;
        }

        public MapaViewModel(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Tipo = Variables.Tipo_Libre;
            this.PosXY = Y * Variables.COLUMNA + X;
            this.Distancia = 0;
        }
    }
}
