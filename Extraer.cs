using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace MatrixIMG
{
    class Extraer
    {
        public void ExtIMG()
        {
            if (!File.Exists("../../imagenes/casillas.png"))
            {
                Console.WriteLine("Imagen no encontrada");
            }
            else
            {
                Console.WriteLine("Extracción de matriz preparada...");

                //Extracción de matriz a partir de la imagen
                Bitmap imgBit = new Bitmap("../../imagenes/casillas.png");
                int tamImg = imgBit.Width;
                int[,] matrix = new int[tamImg, tamImg];

                for (int i = 0; i < tamImg; i++)
                {
                    for (int j = 0; j < tamImg; j++)
                    {
                        Color color = imgBit.GetPixel(j, i);
                        int pixel = (color.R + color.G + color.B) / 3;
                        matrix[j, i] = pixel;
                        char pix = Renderizar(pixel);
                        Console.Write(pix + " ");
                        //Console.Write(matrix[j,i]+" ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("Extracción exitosa!");
                Console.WriteLine("...");
                Modificar modificar = new Modificar();
            }
        }
        public static char Renderizar(int pixel)
        {
            if (pixel >= 250) return '█';
            if (pixel >= 230) return '#';
            if (pixel >= 180) return '%';
            if (pixel >= 130) return '*';
            if (pixel >= 80) return ':';
            if (pixel >= 30) return '.';

            return' ';
        }
    }
}
