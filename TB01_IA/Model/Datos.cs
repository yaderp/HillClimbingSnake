using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB01_IA.ViewModel;

namespace TB01_IA.Model
{
    public class Datos
    {
        
        public List<MapaViewModel> getMapa() {

            List<MapaViewModel> AchMapa = new List<MapaViewModel>();

            string rutaCompleta = "_Mapa.txt";
            string line = "";

            using (StreamReader file = new StreamReader(rutaCompleta))
            {                
                while ((line = file.ReadLine()) != null)                //Leer linea por linea
                {
                    string letra = line;
                    string[] Linea;

                    Linea = letra.Split(',');


                    int posy = Convert.ToInt32(Linea[0]);
                    int posx = Convert.ToInt32(Linea[1]); 
                    int tipo= Convert.ToInt32(Linea[2]);

                    MapaViewModel vmMapa = new MapaViewModel(posx,posy,tipo);

                    AchMapa.Add(vmMapa);
                }

                line = file.ReadToEnd();
                file.Close();
            }

            return AchMapa;
        }

        public void setMapa(List<MapaViewModel> AchMapa)
        {
            try
            {                
                string rutaCompleta = "_Mapa.txt";
                using (StreamWriter Arch = new StreamWriter(rutaCompleta))
                {                    
                    foreach (var item in AchMapa) {
                        string texto = item.Y + "," + item.X + "," + item.Tipo;
                        Arch.WriteLine(texto);
                    }
                    Arch.Close();
                }
            }
            catch
            {

            }
        }

        public List<ImgViewModel> getImg()
        {
            List<ImgViewModel> AchImg = new List<ImgViewModel>();
            string rutaCompleta = "_Img.txt";
            string line = "";

            using (StreamReader file = new StreamReader(rutaCompleta))
            {
                while ((line = file.ReadLine()) != null)                //Leer linea por linea
                {
                    string letra = line;
                    string[] Linea;

                    Linea = letra.Split(',');

                    int posx = Convert.ToInt32(Linea[0]);
                    int posy = Convert.ToInt32(Linea[1]);
                    int direccion = Convert.ToInt32(Linea[2]);
                    ImgViewModel vmImg = new ImgViewModel(posx,posy,direccion,1);

                    AchImg.Add(vmImg);
                }


                line = file.ReadToEnd();
                file.Close();
            }
            return AchImg;
        }

        public void setImg(List<ImgViewModel> AchImg)
        {
            try
            {
                string rutaCompleta = "_Img.txt";
                using (StreamWriter Arch = new StreamWriter(rutaCompleta))
                {
                    foreach (var item in AchImg)
                    {
                        string texto = item.X + "," + item.Y + "," + item.Direccion;
                        Arch.WriteLine(texto);
                    }
                    Arch.Close();
                }
            }
            catch
            {

            }
        }
        

        public List<DatosViewModel> ListaVelocidad()
        {
            List<DatosViewModel> lista = new List<DatosViewModel>();

            lista.Add(new DatosViewModel(150, "- NORMAL -"));
            lista.Add(new DatosViewModel(400, "- LENTA -"));
            lista.Add(new DatosViewModel(50, "- RAPIDO -"));

            return lista;
        }
    }
}
