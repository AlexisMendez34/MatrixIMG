using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MatrixIMG
{
    class Modificar : Extraer
    {
        Bitmap imgBit = new Bitmap("../../imagenes/casillas.png");


        public void Transpuesta(int[,] modMatrix)
        {
            int tamImg = imgBit.Width;

            for (int j = 0; j < tamImg; j++)
            {
                for (int i = 0; i < tamImg; i++)
                {
                    Color color = imgBit.GetPixel(j, i);
                    int pixel = (color.R + color.G + color.B) / 3;
                    modMatrix[j, i] = pixel;
                    char pix = Renderizar(pixel);
                    Console.Write(pix + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\nTranspuesta lista\n\n");
        }

        public void TranspuestaInversa(int[,] modMatrix)
        {
            int tamImg = imgBit.Width;

            for (int j = tamImg - 1; j >= 0; j--)
            {
                for (int i = tamImg - 1; i >= 0; i--)
                {
                    Color color = imgBit.GetPixel(j, i);
                    int pixel = (color.R + color.G + color.B) / 3;
                    modMatrix[j, i] = pixel;
                    char pix = Renderizar(pixel);
                    Console.Write(pix + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\nTranspuesta e inversa lista\n\n");
        }
    }
}
