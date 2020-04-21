using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB01_IA
{
    public class Variables
    {
        // Ubicacion Imagen  4 * 3
        public static string NomImagen = "Imagen/snakeapple.png";

        public static int TotalImagen = 4;

        // Indx Imagen  4
        public static int ABAJO = 0;
        public static int ARRIBA = 1;
        public static int IZQUIERDA = 2;
        public static int DERECHA = 3;


        // Indy Imagen 3
        public static int CABEZA = 0;
        public static int CUERPO = 1;
        public static int MANZANA = 2;
        public static int CAB_DEAR = 3;
        

        // tamaño de las imagenes
        public static int ANCHO = 40;
        public static int ALTO = 40;

        

        // Variables Iniciales

        // Serpiente
        public static int posX_snake = 0;  // maximo COLUMNA - 1
        public static int posY_snake = 0;  // maximo FILA - 1

        //Manzana
        public static int posX_apple = 2;
        public static int posY_apple = 3;

        //tipo Cudrante Mapa
        public static int Tipo_Libre = 0;
        public static int Tipo_Snake = 1;
        public static int Tipo_Apple = 2;

        // tamañano de cuadrado
        public static int DIM = 40;

        //Cantidad de vidas
        public static int VIDAS = 5;


        // dimension del mapa
        public static int FILA = 15;
        public static int COLUMNA = 25;

        public static int TOTAL = FILA * COLUMNA;

        public static int ANCHO_MAPA = COLUMNA * DIM;
        public static int ALTO_MAPA = FILA * DIM;


        public static int TiempoEspera = 10;
    }
}
