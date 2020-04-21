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
    public partial class FrmJuego : Form
    {
        #region  Variables Locales

        int Velocidad;
        List<CaminoViewModel> vmLista;
        List<ImgViewModel> vmListaImg;
        List<MapaViewModel> vmListaMapa;

        ImgViewModel Serpiente = new ImgViewModel(Variables.CABEZA);
        ImgViewModel Manzana = new ImgViewModel(Variables.MANZANA);

        int TamSnake = 1;
        int MaxPunto = 0;

        int CantVidas = Variables.VIDAS;
        bool ActLineas = false;
        #endregion

        public FrmJuego(int speed)
        {
            this.Velocidad = speed;
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            DatosIniciales();
        }

        #region Cargar Juego
        private void DatosIniciales()
        {
            timerJuego.Interval = Velocidad;
            TamSnake = 1;
            MaxPunto = 0;
            
            vmLista = new List<CaminoViewModel>();
            vmListaImg = new List<ImgViewModel>();
            vmListaMapa = new List<MapaViewModel>();

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

            _SaveArchivos();
        }

        private void _SaveArchivos() {
            Model.Datos datos = new Model.Datos();
            datos.setMapa(vmListaMapa);
            datos.setImg(vmListaImg);
        }
        #endregion

        #region Graficos Juego
        private void Gestor_DibujaSnake()
        {
            Graphics g = panelCuadro.CreateGraphics();
            BufferedGraphicsContext espacioBuffer = BufferedGraphicsManager.Current;
            BufferedGraphics Buffer = espacioBuffer.Allocate(g, this.ClientRectangle);
            Buffer.Graphics.Clear(Color.FromArgb(0, 64, 0));

            DibujarTodo(Buffer.Graphics);
            Buffer.Render(g);
        }

        private void DibujarTodo(Graphics dibujo)
        {
            DibujarFondo(dibujo);

            if (ActLineas)
                DibujarCuadro(dibujo);

            Dibujar(dibujo, Manzana);

            foreach (var item in vmListaImg)
                Dibujar(dibujo, item);

            DibujarVidas();
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
                Rectangle porcionAUsar = new Rectangle(0, 0, 25, 20);
                dibuj_Cor.DrawImage(imgtransparente, 20 + 40 * i, 20, porcionAUsar, GraphicsUnit.Pixel);
            }
        }
        private void DibujarCuadro(Graphics dibujo)
        {
            SolidBrush pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
            Pen lapiz = new Pen(Color.Violet);
            Font fuente = new Font("Arial", 10);
            SolidBrush letra = new SolidBrush(Color.FromArgb(37, 56, 125));
            

            foreach (var item in vmListaMapa)
            {
                //dibujo.FillRectangle(pincel, new Rectangle(px * Variables.DIM, py * Variables.DIM, Variables.ANCHO, Variables.ALTO));
                dibujo.DrawRectangle(lapiz, item.X * Variables.ANCHO, item.Y * Variables.DIM, Variables.DIM, Variables.ALTO);
                dibujo.DrawString((item.Y * Variables.COLUMNA + item.X).ToString(), fuente, letra, item.X * Variables.ANCHO, item.Y * Variables.ALTO);
            }            
        }

        #endregion

        #region Gestor Juego
        private void timerJuego_Tick(object sender, EventArgs e)
        {
            Gestor_Juego();
        }

        private void Gestor_Juego()
        {
            if (vmLista.Count() == 0)
            {
                Jugar_Snake();
            }
            else
            {
                MoverSnake(vmLista.First());
                
                Gestor_DibujaSnake();
                vmLista.RemoveAt(0);
                labelRecorrido.Text = "Recorrido : " + vmLista.Count();
            }
        }

        private void Jugar_Snake()
        {
            _SaveArchivos();
            SnakeBL sbl = new SnakeBL();
            var hallado = sbl.ListaCamino(Manzana);

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
                if (MaxPunto < TamSnake)
                    MaxPunto = TamSnake;

                labelMaxPunto.Text = "Max Puntos : " + MaxPunto;
                
                DatosIniciales();
                
                if (CantVidas == 0) {
                    timerJuego.Enabled = false;
                    MessageBox.Show("FIN DEL JUEGO", "SALIR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                CantVidas--;
            }
        }

        #endregion

        #region Funciones basicas
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


        private void FrmInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (ActLineas)
                {
                    ActLineas = false;
                }
                else {
                    ActLineas = true;
                }
            }

            if (e.KeyData == Keys.Space)
            {
                if (timerJuego.Enabled)
                {
                    timerJuego.Enabled = false;
                }
                else
                {
                    timerJuego.Enabled = true;
                }
            }

            if (e.KeyData == Keys.Escape)
            {
                DatosIniciales();
            }

            Gestor_DibujaSnake();
        }
        #endregion
    }
}
