using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TB01_IA.ViewModel;
using TB01_IA.BL;

namespace TB01_IA
{
    public partial class FrmInicio : Form
    {
        List<CaminoViewModel> vmLista = null;

        List<ImgViewModel> vmListaImg = new List<ImgViewModel>();
        List<MapaViewModel> vmListaMapa = new List<MapaViewModel>();


        ImgViewModel Serpiente = new ImgViewModel(Variables.CABEZA);
        ImgViewModel Manzana = new ImgViewModel(Variables.MANZANA);

        int TamSnake = 1;
        int MaxPunto = 0;
        int CantVidas = Variables.VIDAS;

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            DatosIniciales();
        }

        private void DatosIniciales()
        {
            vmLista = new List<CaminoViewModel>();

            TamSnake = 1;
            for (int i = 0; i < Variables.FILA; i++)
            {
                for (int j = 0; j < Variables.COLUMNA; j++)
                {
                    MapaViewModel temp = new MapaViewModel(j, i);
                    vmListaMapa.Add(temp);
                }
            }

            vmListaImg.Add(Serpiente);
            vmListaMapa[Serpiente.PosXY].Tipo = Variables.Tipo_Snake;
            vmListaMapa[Manzana.PosXY].Tipo = Variables.Tipo_Apple;        
        }

        #region Graficos Juego
        private void Gestor_Snake()
        {
            Graphics g = panelCuadro.CreateGraphics();
            BufferedGraphicsContext espacioBuffer = BufferedGraphicsManager.Current;
            BufferedGraphics Buffer = espacioBuffer.Allocate(g, this.ClientRectangle);
            Buffer.Graphics.Clear(Color.FromArgb(210, 214, 230));

            DibujarTodo(Buffer.Graphics);
            Buffer.Render(g);
        }

        private void DibujarTodo(Graphics dibujo)
        {

            foreach (var item in vmListaMapa)
            {
                DibujarCuadro(dibujo, item.X, item.Y, item.Tipo);
            }
            //DibujarFondo(dibujo);
            Dibujar(dibujo, Manzana);

            foreach (var item in vmListaImg)
            {
                Dibujar(dibujo, item);
            }
        }

        private void Dibujar(Graphics dibujo, ImgViewModel dato)
        {
            Bitmap imagen = new Bitmap(Variables.NomImagen);
            Bitmap imgtransparente = new Bitmap(imagen);
            imgtransparente.MakeTransparent(imgtransparente.GetPixel(1, 1));
            Rectangle porcionAUsar = new Rectangle(Variables.ANCHO * dato.Direccion, Variables.ALTO * dato.Indy, Variables.ANCHO, Variables.ALTO);
            dibujo.DrawImage(imgtransparente, dato.X * Variables.DIM, dato.Y * Variables.DIM, porcionAUsar, GraphicsUnit.Pixel);
        }

        private void DibujarFondo(Graphics dibujo)
        {
            Bitmap imagen = new Bitmap("Imagen/fondo.png");
            dibujo.DrawImage(imagen, 0, 0, Variables.ANCHO_MAPA, Variables.ALTO_MAPA);
        }

        private void DibujarVidas()
        {
            Graphics dibuj_Cor;
            dibuj_Cor = panelInformacion.CreateGraphics();
            for (int i = 0; i < Variables.VIDAS; i++)
            {
                Bitmap imagen = new Bitmap("Imagen/corazon.png");
                if (i >= CantVidas)
                    imagen = new Bitmap("Imagen/corazoff.png");

                Bitmap imgtransparente = new Bitmap(imagen);
                imgtransparente.MakeTransparent(imgtransparente.GetPixel(1, 1));
                Rectangle porcionAUsar = new Rectangle(0, 0, 30, 30);
                dibuj_Cor.DrawImage(imgtransparente, 500 + 40 * i, 40, porcionAUsar, GraphicsUnit.Pixel);
            }
        }
        private void DibujarCuadro(Graphics dibujo, int px, int py, int tipo)
        {

            SolidBrush letra = new SolidBrush(Color.FromArgb(37, 56, 125));
            Pen lapiz = new Pen(Color.Violet);
            SolidBrush pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
            Font fuente = new Font("Arial", 10);

            if (tipo == 1)
                pincel = new SolidBrush(Color.FromArgb(100, 255, 100));

            if (tipo == 2)
                pincel = new SolidBrush(Color.FromArgb(255, 100, 100));


            dibujo.FillRectangle(pincel, new Rectangle(px * Variables.DIM, py * Variables.DIM, Variables.ANCHO, Variables.ALTO));

            dibujo.DrawRectangle(lapiz, px * Variables.ANCHO, py * Variables.DIM, Variables.DIM, Variables.ALTO);

            dibujo.DrawString((py * Variables.COLUMNA + px).ToString(), fuente, letra, px * Variables.ANCHO, py * Variables.ALTO);
        }

        #endregion

        private void timerJuego_Tick(object sender, EventArgs e)
        {
            HillClimbing();
        }

        private void HillClimbing()
        {

            if (vmLista.Count() == 0)
            {
                Jugar_Snake();
            }
            else
            {
                MoverSnake(vmLista.First());
                Gestor_Snake();
                vmLista.RemoveAt(0);
            }

        }

        private void Jugar_Snake()
        {
            SnakeBL sbl = new SnakeBL();

            var hallado = sbl.ListaCamino(vmListaMapa, vmListaImg, Manzana);

            if (hallado != null)
            {
                foreach (var item in hallado) {
                    if (vmListaMapa[item.PosXY].Tipo == 1) {
                        int numero = item.X + 4;
                    }
                }

                vmLista = hallado;
            }
            else {
                timerJuego.Enabled = true;
            }
        }

        private void MoverSnake(CaminoViewModel vmCamino)
        {
            

            if (vmCamino.Distancia == 0)
            {
                ComerManzana(vmCamino.X, vmCamino.Y, vmCamino.Direccion);
                return;
            }

            int posxy = vmListaImg[TamSnake - 1].PosXY;

            for (int i = TamSnake - 1; i > 0; i--)
            {
                vmListaImg[i].X = vmListaImg[i - 1].X;
                vmListaImg[i].Y = vmListaImg[i - 1].Y;
                vmListaImg[i].PosXY = vmListaImg[i - 1].PosXY;
            }

            Serpiente.X = vmCamino.X;
            Serpiente.Y = vmCamino.Y;
            Serpiente.Direccion = vmCamino.Direccion;
            Serpiente.PosXY = vmCamino.PosXY;


            vmListaImg[0] = Serpiente;

            vmListaMapa[Serpiente.PosXY].Tipo = Variables.Tipo_Snake;
            vmListaMapa[posxy].Tipo = Variables.Tipo_Libre;
        }

        private void ComerManzana(int posx, int posy, int direc)
        {
            /////////////////// AGREGAR COLA /////////////////////
            ImgViewModel Temp = new ImgViewModel(posx, posy, direc, Variables.CABEZA);

            vmListaImg[0].Indy = Variables.CUERPO;
            vmListaImg[0].Direccion = direc;

            vmListaImg.Insert(0, Temp);

            vmListaMapa[Temp.PosXY].Tipo = Variables.Tipo_Snake;
            Serpiente = Temp;
            TamSnake++;
            labelPuntos.Text = "Puntos : " + TamSnake;

            AgregaManzana();
        }

        private void AgregaManzana()
        {
            ///////////////  AGREGAR MANZANA ///////////////////////
            bool Act_Ap = true;
            Random rnd = new Random();
            int posA = rnd.Next(0, Variables.TOTAL);

            while (Act_Ap)
            {
                if (vmListaMapa[posA].Tipo == 0)
                {
                    Act_Ap = false;
                }
                else
                {
                    posA++;
                    if (posA == Variables.TOTAL)
                    {
                        posA = 0;
                    }
                }
            }

            

            Manzana.X = vmListaMapa[posA].X;
            Manzana.Y = vmListaMapa[posA].Y;
            Manzana.PosXY = vmListaMapa[posA].PosXY;
            Manzana.Direccion = Manzana.PosXY % 4;

            vmListaMapa[Manzana.PosXY].Tipo = Variables.Tipo_Apple;
        }
    }
}
