using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB01_IA.ViewModel;
namespace TB01_IA.Model
{
    public class Datos
    {
        public int PosX { set; get; }
        public int PosY { set; get; }


        public List<MapaViewModel> getMapa() {

            List<MapaViewModel> AchMapa = new List<MapaViewModel>();

            return AchMapa;
        }

        public void setMapa(List<MapaViewModel> AchMapa)
        {
            
        }

        public List<ImgViewModel> getImg()
        {
            List<ImgViewModel> AchImg = new List<ImgViewModel>();

            return AchImg;
        }

        public void setImg(List<MapaViewModel> AchImg)
        {

        }

    }
}
