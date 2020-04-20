using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB01_IA.ViewModel
{
    public class ImgViewModel
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Direccion { set; get; }
        public int Indy { set; get; }
        public int PosXY { set; get; }
        public ImgViewModel()
        {

        }
        public ImgViewModel(int X, int Y, int Direccion, int Indy)
        {
            this.X = X;
            this.Y = Y;
            this.Direccion = Direccion;
            this.Indy = Indy;
            this.PosXY = Y * Variables.COLUMNA + X;
        }
        public ImgViewModel(int Tipo)
        {
            this.Direccion = Variables.DERECHA;
            this.Indy = Tipo;

            if (Tipo == Variables.CABEZA)
            {
                this.X = Variables.posX_snake;
                this.Y = Variables.posY_snake;
            }
            else
            {
                this.X = Variables.posX_apple;
                this.Y = Variables.posY_apple;
            }

            this.PosXY = Y * Variables.COLUMNA + X;
        }

    }
}
