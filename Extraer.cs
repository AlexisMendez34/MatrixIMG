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
        int[,] matrix;
        public int[,] ExtIMG(string archivo)
        {
            string img = "../../imagenes/" + archivo;
            if (!File.Exists(img))
            {
                Console.WriteLine("Imagen no encontrada");
                matrix = new int[0, 0];
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Extracción de matriz preparada\n...");

                //Extracción de matriz a partir de la imagen
                Bitmap imgBit = new Bitmap(img);
                int tamImg = imgBit.Width;
                if(imgBit.Width != imgBit.Height)
                {
                    Console.WriteLine("No es un a imagen cuadrada.");
                    matrix = new int[0, 0];
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                    return matrix;
                }
                matrix = new int[tamImg, tamImg];

                //Recorrido del arreglo bidimensional (matriz) para almacenar los pixeles de la imagen monocromática en la matriz
                for (int i = 0; i < tamImg; i++)
                {
                    for (int j = 0; j < tamImg; j++)
                    {
                        Color color = imgBit.GetPixel(j, i);
                        int pixel = (color.R + color.G + color.B) / 3;
                        matrix[j, i] = pixel;
                        /*char pix = Renderizar(pixel);
                        Console.Write(pix + " ");*/
                        //Console.Write(matrix[j,i]+" ");
                    }
                    //Console.Write("\n");
                }
                Console.WriteLine("Extracción exitosa!");
                Console.WriteLine("...");
                //Modificar modificar = new Modificar();
            }
            return matrix;
        }
        /*public static char Renderizar(int pixel)
        {
            if (pixel >= 250) return '█';
            if (pixel >= 230) return '#';
            if (pixel >= 180) return '%';
            if (pixel >= 130) return '*';
            if (pixel >= 80) return ':';
            if (pixel >= 30) return '.';

            return' ';
        }*/
    }
}
