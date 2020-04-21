using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB01_IA.ViewModel;

namespace TB01_IA.BL
{
    public class SnakeBL
    {
        private List<CaminoViewModel> ListaBusqueda = null;
        private List<CaminoViewModel> vmLista = null;

        private List<ImgViewModel> ListaImg = null;
        private List<MapaViewModel> ListaMapa = null;

        private ImgViewModel vmSerpiente = null;
        private ImgViewModel vmManzana = null;

        int TamSnake = 0;

        private void _UpdateArchivos()
        {
            Model.Datos datos = new Model.Datos();
            ListaMapa = datos.getMapa();
            ListaImg= datos.getImg();
        }

        public List<CaminoViewModel> ListaCamino(ImgViewModel manza)
        {
            _UpdateArchivos();

            vmSerpiente = ListaImg[0];
            vmManzana = manza;

            TamSnake = ListaImg.Count();

            calcularRecorrido();

            if (vmLista != null)
                return vmLista;
            else
                return null;
        }

        private void calcularRecorrido()
        {

            CaminoViewModel camino = new CaminoViewModel(vmSerpiente.X, vmSerpiente.Y, null);
            ListaBusqueda = new List<CaminoViewModel>();
            ListaBusqueda.Add(camino);

            int cantBus = 1;

            for (int i = 0; i < cantBus;i++) {
                if (ListaBusqueda[i].vmPadre != null)
                {
                    vmLista = new List<CaminoViewModel>();
                    GuardarCamino(ListaBusqueda[i]);

                    for (int j = 0; j < vmLista.Count(); j++)
                    {
                        MoverSnake(vmLista[j]);
                    }
                }

                var hallado = BuscarManzana(ListaBusqueda[i]);
                _UpdateArchivos();

                vmSerpiente = ListaImg[0];

                if (hallado != null)
                {
                    vmLista = new List<CaminoViewModel>();
                    GuardarCamino(hallado);

                    return;
                }

                cantBus = ListaBusqueda.Count();
            }
            // No mas jugadas
        }
        
        private void GuardarCamino(CaminoViewModel vmCamino)
        {

            if (vmCamino.vmPadre != null)
            {
                vmLista.Insert(0, vmCamino);
                GuardarCamino(vmCamino.vmPadre);
            }
        }

        private CaminoViewModel BuscarManzana(CaminoViewModel vmCamino)
        {
            //           
            var LstCaminos = getCaminos(vmCamino);

            if (LstCaminos.Count() > 0)
            {
                for (int i = 1; i < LstCaminos.Count(); i++)
                {
                    ListaBusqueda.Add(LstCaminos[i]);
                }

                var camino = LstCaminos[0];                

                if (camino.Distancia == 0)
                {
                    return camino;
                }
                else
                {
                    MoverSnake(camino);
                    return BuscarManzana(camino);
                }
            }
            return null;
        }

        private List<CaminoViewModel> getCaminos(CaminoViewModel vmPadre)
        {
            List<CaminoViewModel> vmCamino = new List<CaminoViewModel>();
            //derecha 
            CaminoViewModel temp = ValidaCamino(1, 0, Variables.DERECHA);
            if (temp != null)
            {
                temp.vmPadre = vmPadre;
                vmCamino.Add(temp);
            }

            //Abajo
            temp = ValidaCamino(0, 1, Variables.ABAJO);
            if (temp != null)
            {
                temp.vmPadre = vmPadre;
                vmCamino.Add(temp);
            }

            //izquierda

            temp = ValidaCamino(-1, 0, Variables.IZQUIERDA);
            if (temp != null)
            {
                temp.vmPadre = vmPadre;
                vmCamino.Add(temp);
            }
            //arriba
            temp = ValidaCamino(0, -1, Variables.ARRIBA);
            if (temp != null)
            {
                temp.vmPadre = vmPadre;
                vmCamino.Add(temp);
            }

            return vmCamino.OrderBy(x => x.Distancia).ToList();
        }

        private CaminoViewModel ValidaCamino(int dx, int dy, int dire)
        {
            int posx = vmSerpiente.X + dx;
            int posy = vmSerpiente.Y + dy;

            if (posx >= 0 && posx < Variables.COLUMNA && posy >= 0 && posy < Variables.FILA)
            {
                int posFinal = posy * Variables.COLUMNA + posx;



                int tipoxy = ListaMapa[posFinal].Tipo;

                if (ListaMapa[posFinal].Tipo != Variables.Tipo_Snake)
                {
                    CaminoViewModel temp = new CaminoViewModel(posx, posy, null);
                    temp.Distancia = Math.Abs(temp.X - vmManzana.X) + Math.Abs(temp.Y - vmManzana.Y);
                    temp.Direccion = dire;
                    return temp;
                }
            }

            return null;
        }

        private void MoverSnake(CaminoViewModel vmCamino)
        {
            int posxy = ListaImg[TamSnake - 1].PosXY;

            for (int i = TamSnake - 1; i > 0; i--)
            {
                ListaImg[i].X = ListaImg[i - 1].X;
                ListaImg[i].Y = ListaImg[i - 1].Y;
                ListaImg[i].PosXY = ListaImg[i - 1].PosXY;
            }

            vmSerpiente.X = vmCamino.X;
            vmSerpiente.Y = vmCamino.Y;
            vmSerpiente.Direccion = vmCamino.Direccion;
            vmSerpiente.PosXY = vmCamino.PosXY;


            ListaImg[0] = vmSerpiente;

            ListaMapa[vmSerpiente.PosXY].Tipo = Variables.Tipo_Snake;
            ListaMapa[posxy].Tipo = Variables.Tipo_Libre;
        }
    }
}
