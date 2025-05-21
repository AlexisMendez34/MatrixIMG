using System;
using System.Drawing;

namespace MatrixIMG
{
    class Construir
    {
        public void GuardarImagenDesdeMatriz(Color[,] matriz, string rutaArchivo)
        {
            int ancho = matriz.GetLength(0);
            int alto = matriz.GetLength(1);

            using (Bitmap imagen = new Bitmap(ancho, alto))
            {
                for (int y = 0; y < alto; y++)
                {
                    for (int x = 0; x < ancho; x++)
                    {
                        imagen.SetPixel(x, y, matriz[x, y]);
                    }
                }

                imagen.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"Imagen guardada en: {rutaArchivo}");
            }
        }
    }
}
