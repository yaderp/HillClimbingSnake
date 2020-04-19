using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IA_TB1.ViewModel;
namespace IA_TB1
{
    public partial class FrmSnake : Form
    {
        private List<ImgViewModel> vmListaImg = new List<ImgViewModel>();
        private List<MapaViewModel> vmListaMapa = new List<MapaViewModel>();

        private int Direccion = Variables.DERECHA;

        private ImgViewModel Serpiente = new ImgViewModel(Variables.CABEZA);
        private ImgViewModel Manzana = new ImgViewModel(Variables.MANZANA);

        private int TamSnake = 1;
        private int MaxPunto = 0;
        private int CantVidas = Variables.VIDAS;

        bool pintaRecuadro = false;

        bool FinJuego = false;
        bool CambioImg = true;
        public FrmSnake()
        {
            InitializeComponent();
        }


        private void DatosIniciales() {
            TamSnake = 1;
            for (int i = 0; i < Variables.FILA; i++) {
                for (int j = 0; j < Variables.COLUMNA; j++) {
                    MapaViewModel temp = new MapaViewModel(j, i);
                    vmListaMapa.Add(temp);
                }
            }      
            
            vmListaImg.Add(Serpiente);

            vmListaMapa[Serpiente.PosXY].Tipo = Variables.Tipo_Snake;
            vmListaMapa[Manzana.PosXY].Tipo = Variables.Tipo_Apple;
        }

        private void FrmSnake_Load(object sender, EventArgs e)
        {
            DibujarVidas();
            DatosIniciales();
        }

        private void Gestor_Snake() {
            Graphics g = panelCuadro.CreateGraphics();
            BufferedGraphicsContext espacioBuffer = BufferedGraphicsManager.Current;
            BufferedGraphics Buffer = espacioBuffer.Allocate(g, this.ClientRectangle);
            Buffer.Graphics.Clear(Color.FromArgb(210, 214, 230));

            DibujarTodo(Buffer.Graphics);
            Buffer.Render(g);
        }

        private void DibujarTodo(Graphics dibujo) {

            //foreach (var item in vmListaMapa)
            //{
            //    DibujarCuadro(dibujo, item.X, item.Y, item.Tipo);
            //}
            DibujarFondo(dibujo);
            Dibujar(dibujo, Manzana);

            foreach (var item in vmListaImg) {               
                Dibujar(dibujo, item);

            }
        }

        private void AddSnake(MapaViewModel vmMapa) {

            ImgViewModel Temp = new ImgViewModel(vmMapa.X, vmMapa.Y, vmMapa.Direccion, Variables.CABEZA);

            vmListaImg[0].Indy = Variables.CUERPO;
            vmListaImg[0].Direccion = vmMapa.Direccion;

            vmListaImg.Insert(0, Temp);

            vmListaMapa[Temp.PosXY].Tipo = Variables.Tipo_Snake;
            Serpiente = Temp;
            TamSnake++;
            labelPuntos.Text = "Puntos : " + TamSnake;

            ///////////////  AGREGAR MANZANA ///////////////////////
            bool Act_Ap = true;
            Random rnd = new Random();
            int posA = rnd.Next(0, Variables.TOTAL);

            while (Act_Ap) {
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

        private void Dibujar(Graphics dibujo, ImgViewModel dato){

            //dibujo = panelCuadro.CreateGraphics();
            Bitmap imagen = new Bitmap(Variables.NomImagen);
            Bitmap imgtransparente = new Bitmap(imagen);
            imgtransparente.MakeTransparent(imgtransparente.GetPixel(1, 1));
            Rectangle porcionAUsar = new Rectangle(Variables.ANCHO * dato.Direccion, Variables.ALTO * dato.Indy, Variables.ANCHO, Variables.ALTO);
            dibujo.DrawImage(imgtransparente, dato.X * Variables.DIM, dato.Y * Variables.DIM, porcionAUsar, GraphicsUnit.Pixel);
        }

        #region Fondo mapa
        private void DibujarFondo(Graphics dibujo)
        {
            Bitmap imagen = new Bitmap("Imagen/fondo.png");
            dibujo.DrawImage(imagen, 0, 0, Variables.ANCHO_MAPA, Variables.ALTO_MAPA);
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

            //dibujo.DrawString(tipo.ToString(), fuente, letra, px*Variables.ANCHO, py*Variables.ALTO);
        }
        #endregion
        //private void MoveSanake(int dx,int dy) {

        //    int posx = Serpiente.X + dx;
        //    int posy = Serpiente.Y + dy;
            
        //    if (posx >= 0 && posx < Variables.COLUMNA && posy >= 0 && posy < Variables.FILA)
        //    {
        //        int posFinal= posy * Variables.COLUMNA + posx;
        //        int tipoxy = vmListaMapa[posFinal].Tipo;
        //        if (tipoxy == Variables.Tipo_Libre)
        //        {
        //            MoverSnake(posx,posy);
        //            Gestor_Snake();
        //        }
        //        else {
        //            if (tipoxy == 2)
        //            {
        //                AddSnake(vmListaMapa[posFinal]);
        //            }
        //            else {
        //                CantVidas--;
        //                labelVidas.Text = "0" + CantVidas;
        //            }
        //        }

        //    }
        //    else {
        //        CantVidas--;
        //        labelVidas.Text = "0" + CantVidas;
        //    }
        //}

        private void MoverSnake(int posx,int posy,int dire) {

            int posxy = vmListaImg[TamSnake - 1].PosXY;

            for (int i = TamSnake - 1; i > 0; i--)
            {
                vmListaImg[i].X = vmListaImg[i - 1].X;
                vmListaImg[i].Y = vmListaImg[i - 1].Y;
                vmListaImg[i].PosXY = vmListaImg[i - 1].PosXY;
            }

            Serpiente.X = posx;
            Serpiente.Y = posy;
            Serpiente.Direccion = dire;
            Serpiente.PosXY = posy * Variables.COLUMNA + posx;

            vmListaImg[0] = Serpiente;

            vmListaMapa[Serpiente.PosXY].Tipo = Variables.Tipo_Snake;
            vmListaMapa[posxy].Tipo = Variables.Tipo_Libre;
            
        }
        
        private void pictureBoxIniciar_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
            CantVidas = Variables.VIDAS;
            vmListaImg[0].Indy = Variables.CABEZA;
            FinJuego = false;
        }


        private void ReiniciarJuego() { 
            vmListaImg.Clear();
            vmListaMapa.Clear();
            DatosIniciales(); 
        }
     
        private void FrmSnake_KeyDown(object sender, KeyEventArgs e)
        {
            int dx = 0;
            int dy = 0;
            if (e.KeyData == Keys.Right)
            {
                this.Text = "Mover Derecha";
                Direccion = Variables.DERECHA;
                dx = 1;
                dy = 0;
            }

            if (e.KeyData == Keys.Left)
            {
                this.Text = "Mover Izquierda";
                Direccion = Variables.IZQUIERDA;
                dx = -1;
                dy = 0;
            }

            if (e.KeyData == Keys.Up)
            {
                this.Text = "Mover Arriba";
                Direccion = Variables.ARRIBA;
                dx = 0;
                dy = -1;
            }

            if (e.KeyData == Keys.Down)
            {
                this.Text = "Mover Abajo";
                Direccion = Variables.ABAJO;
                dx = 0;
                dy = 1;
            }

        }

        private void timerJuego_Tick(object sender, EventArgs e)
        {
            
            if (FinJuego)
            {
                pictureBoxIniciar.Enabled = true;
                
                if (CambioImg)
                {
                    vmListaImg[0].Indy = Variables.CAB_DEAR;
                    CambioImg = false;
                }
                else
                {
                    vmListaImg[0].Indy = Variables.CABEZA;
                    CambioImg = true;
                }
            }
            else {
                HillClimbing();
                
                DibujarVidas();
            }
            Gestor_Snake();
        }

        // preferencia derecha abajo izquierda arriba ---> Sentido horario
        private void HillClimbing() {

            List<MapaViewModel> vmCamino = new List<MapaViewModel>();
            //derecha 
            MapaViewModel temp = ValidaMovimiento(1, 0,Variables.DERECHA); 
            if (temp != null) {
                if (temp.Distancia == 0)
                {
                    return;
                }
                vmCamino.Add(temp);
                
            }
            //izquierda

            temp = ValidaMovimiento(-1, 0, Variables.IZQUIERDA);
            if (temp != null)
            {
                if (temp.Distancia == 0)
                {
                    return;
                }
                vmCamino.Add(temp);
            }

            //Abajo
            temp = ValidaMovimiento(0, 1, Variables.ABAJO); 
            if (temp != null)
            {
                if (temp.Distancia == 0)
                {
                    return;
                }
                vmCamino.Add(temp);
            }
            
            //arriba
            temp = ValidaMovimiento(0, -1, Variables.ARRIBA); 
            if (temp != null)
            {
                if (temp.Distancia == 0)
                {
                    return;
                }
                vmCamino.Add(temp);
            }

            if (vmCamino.Count() > 0)
            {
                int menor = 0;
                int mayor = 0;
                for (int i = 1; i < vmCamino.Count(); i++)
                {
                    if (vmCamino[i].Distancia < vmCamino[menor].Distancia)
                    {
                        menor = i;
                    }

                    if (vmCamino[i].Espacio > vmCamino[mayor].Espacio)
                    {
                        mayor = i;
                    }
                }
                MoverSnake(vmCamino[menor].X, vmCamino[menor].Y, vmCamino[menor].Direccion);

                //if (vmCamino[menor].Espacio >= 1)
                //{
                //    Direccion = vmCamino[menor].Direccion;
                //    MoverSnake(vmCamino[menor].X, vmCamino[menor].Y);
                //}

                //else
                //{
                //    Direccion = vmCamino[mayor].Direccion;
                //    MoverSnake(vmCamino[mayor].X, vmCamino[mayor].Y);
                //}
            }
            else {

                if (TamSnake > MaxPunto)
                    MaxPunto = TamSnake;
                labelMaxPunto.Text = "Max Puntos : " + MaxPunto;

                CantVidas--;
                if (CantVidas == 0)
                {
                    FinJuego = true;                
                }
                else {                    
                    ReiniciarJuego();
                }
                
            }            
        }

        private void DibujarVidas() {
            Graphics dibuj_Cor;
            dibuj_Cor = panelInformacion.CreateGraphics();
            for (int i = 0; i < Variables.VIDAS; i++) {
                Bitmap imagen = new Bitmap("Imagen/corazon.png");
                if (i >= CantVidas)
                    imagen = new Bitmap("Imagen/corazoff.png");

                Bitmap imgtransparente = new Bitmap(imagen);
                imgtransparente.MakeTransparent(imgtransparente.GetPixel(1, 1));
                Rectangle porcionAUsar = new Rectangle(0, 0, 30, 30);
                dibuj_Cor.DrawImage(imgtransparente,500 + 40 * i, 40, porcionAUsar, GraphicsUnit.Pixel);
            }
        }

        private MapaViewModel ValidaMovimiento(int dx,int dy,int dire)
        {
            int posx = Serpiente.X + dx;
            int posy = Serpiente.Y + dy;

            if (posx >= 0 && posx < Variables.COLUMNA && posy >= 0 && posy < Variables.FILA)
            {
                int posFinal = posy * Variables.COLUMNA + posx;
                int tipoxy = vmListaMapa[posFinal].Tipo;
                
                if (tipoxy == Variables.Tipo_Snake)
                {
                    return null;
                }

                MapaViewModel temp = new MapaViewModel(posx, posy,dire);          

                if (tipoxy == Variables.Tipo_Apple)
                {
                    AddSnake(temp);
                }

                if (tipoxy == Variables.Tipo_Libre)
                {
                    temp.Distancia = Math.Abs(temp.X - Manzana.X) + Math.Abs(temp.Y - Manzana.Y);
                    temp.Espacio = CalculaEspacio(temp.X, temp.Y, dx, dy);
                }

                return temp;
            }
            return null;
        }


        private int CalculaEspacio(int posx, int posy,int dx,int dy) {
            // arriba abajo
            int contador = 0;

            for (int i = 0; i < Variables.CantEspacios; i++) {
                posx = posx + dx;
                posy = posy + dy;
                
                if (posx >= 0 && posx < Variables.COLUMNA && posy >= 0 && posy < Variables.FILA)
                {
                    int posFinal = posy * Variables.COLUMNA + posx;
                    if (vmListaMapa[posFinal].Tipo == 0)
                    {
                        contador++;
                    }
                    else {
                        return contador;
                    }
                }               
            }
            return contador;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pintaRecuadro)
            {
                pintaRecuadro = true;
            }
            else {
                pintaRecuadro = false;
            }
        }
    }
}
