using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB01_IA.ViewModel
{
    public class CaminoViewModel
    {
        public int ID { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public int PosXY { set; get; }
        public int Distancia { set; get; }
        public int Direccion { set; get; }
        public int ID_Padre { set; get; }
        public CaminoViewModel vmPadre { set; get; }

        public CaminoViewModel(int X, int Y, CaminoViewModel vmPadre)
        {

            this.X = X;
            this.Y = Y;
            this.PosXY = Y * Variables.COLUMNA + X;
            this.vmPadre = vmPadre;
        }
    }
}
